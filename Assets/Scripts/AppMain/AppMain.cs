using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System;
using System.Threading;


//Lua全局代理
public class AppMain : MonoBehaviour
{
    public static LuaEnv luaAgent = null;
    public Injection[] injections;
    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second 
    private Action luaStart;
    private Action luaUpdate;
    private Action luaTick;
    private Action luaOnDestroy;
    private LuaTable scriptEnv;

    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        //CS init       
        TimerMgr.Initilize();
        ResMgr.Instance.initialize();
        ManifestMgr.Instance.initialize();
        PoolMgr.Instance.initialize();
        LoaderMgr.Instance.initialize();


        //Lua init
        luaAgent = new LuaEnv();
        luaAgent.DoString("require 'LuaInit'");

        scriptEnv = luaAgent.NewTable();
        LuaTable meta = luaAgent.NewTable();
        meta.Set("__index", luaAgent.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();
        scriptEnv.Set("self", this);
        foreach (var injection in injections)
        {
            scriptEnv.Set(injection.name, injection.value);
        }
        luaAgent.DoString("require 'LuaBehavior'", "LuaBehaviour", scriptEnv);
        // Action luaAwake = scriptEnv.Get<Action>("awake");
        scriptEnv.Get("start", out luaStart);
        scriptEnv.Get("update", out luaUpdate);
        scriptEnv.Get("onTick", out luaTick);
        scriptEnv.Get("ondestroy", out luaOnDestroy);

        if (luaStart != null)
        {
            luaStart();
        }
        // initClock();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //lua计时器
    //    if (luaUpdate != null)
    //    {
    //        luaUpdate();
    //    }
    //}

    private void initClock()
    {
        if (_clockThread == null)
        {
            //启动定时器去计算
            _clockThread = new Thread(new ThreadStart(tick));
            _clockThread.IsBackground = true;
        }
        if (!_clockThread.IsAlive)
        {
            _clockThread.Start();
        }
    }

    private int _interval = 20;
    private Thread _clockThread;

    private void tick()
    {
        while (true)
        {
            Thread.Sleep(_interval);
            if (luaTick != null)
            {
                luaTick();
            }
        }
    }

    void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
            luaOnDestroy();
        }
        luaOnDestroy = null;
        luaUpdate = null;
        luaStart = null;
        scriptEnv.Dispose();
        injections = null;
    }

}
