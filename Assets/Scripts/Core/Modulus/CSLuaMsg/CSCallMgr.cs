using System;
using System.Collections.Generic;
using XLua;
using UnityEngine;


public class CSCallMgr
{
    private static CSCallMgr instance;
    public static CSCallMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CSCallMgr();
            }
            return instance;
        }
    }

    private CSExtend.LuaEventName luaEventMgr;
    protected CSExtend.LuaEventName LuaEventMgr
    {
        get
        {
            if (luaEventMgr == null)
            {
                luaEventMgr = AppMain.luaAgent.Global.GetInPath<CSExtend.LuaEventName>("sendMsg");
            }
            return luaEventMgr;
        }
    }
    public void initialize()
    {

    }

    public void sendLuaMsg(string msg)
    {
        if (LuaEventMgr != null)
        {
            LuaEventMgr(msg);
        }
    }

    public void onDispose()
    {

    }
}

