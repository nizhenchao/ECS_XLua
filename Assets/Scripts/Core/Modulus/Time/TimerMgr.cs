using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerMgr : MonoBehaviour
{
    const string Tag = "_twlTimer";
    static private TimerMgr _instance;
    static public TimerMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                Initilize();
            }
            return _instance;
        }
    }
    static public void Initilize()
    {
        if (_instance != null)
            return;
        if (_instance == null)
        {
            GameObject obj = GameObject.Find(Tag);
            if (obj == null)
            {
                obj = new GameObject();
                obj.name = Tag;
            }
            _instance = obj.GetComponent<TimerMgr>();
            if (_instance == null)
            {
                _instance = obj.AddComponent<TimerMgr>();
            }
            _instance.init();
            GameObject.DontDestroyOnLoad(obj);
        }
    }

    private NormalTimePool normalPool;
    private FixedTimePool fixedPool;

    private void init()
    {
        normalPool = new NormalTimePool();
        fixedPool = new FixedTimePool();
    }

    public void Update()
    {
        double nowTime = TimerUtils.getMillTimer();
        normalPool.doCheck(nowTime);
        fixedPool.doCheck(nowTime); 
    }

    public void onDispose()
    {

    }

    #region 提供静态方法

    /// <summary>
    /// 添加一个计时器
    /// </summary>
    /// <param name="endCount"></param> 计数 
    /// <param name="eHandler"></param> 每次回调
    /// <param name="cHandler"></param>完成回调
    /// <param name="interval"></param> 间隔
    private static long addTimer(int endCount, Action<int> eHandler, Action<int> cHandler = null, int interval = 1)
    {
        long id = TimerUtils.getTimeId();
        BaseTimeHandler handler = new BaseTimeHandler(endCount, eHandler, cHandler, interval);
        Instance.normalPool.addTimer(id, handler);
        return id;
    }
    //添加一个毫秒级计时器
    public static long addMillHandler(int endCount, Action<int> eHandler, Action<int> cHandler = null, int interval = 1)
    {
        return addTimer(endCount, eHandler, cHandler, interval);
    }
    //添加一个秒级计时器
    public static long addSecHandler(int endCount, Action<int> eHandler, Action<int> cHandler = null, int interval = 1)
    {
        interval = interval * 1000;
        return addTimer(endCount, eHandler, cHandler, interval);
    }
    //添加一个分钟级计时器
    public static long addMinHandler(int endCount, Action<int> eHandler, Action<int> cHandler = null, int interval = 1)
    {
        interval = interval * 1000 * 60;
        return addTimer(endCount, eHandler, cHandler, interval);
    }
    //添加一个永久毫秒级计时器
    public static long addEveryMillHandler(Action<int> eHandler, int interval = 1)
    {
        long id = TimerUtils.getTimeId();
        EveryTimeHandler handler = new EveryTimeHandler(-1, eHandler, eHandler, interval);
        Instance.fixedPool.addTimer(id, handler);
        return id;
    }
    //移除一个计时器
    public static void removeTimer(long uid) {

    }
    #endregion
}

