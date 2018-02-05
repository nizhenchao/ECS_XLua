using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI管理器 C#只用到加载界面
//提供Lua获取画布方法
//UICanvas为内建资源
public class UIMgr
{
    private const string canvasPath = "UICanvas";
    private static UIMgr instance;
    public static UIMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIMgr();
            }
            return instance;
        }
    }
    private Transform uiCanvas;
    protected Transform UICanvas
    {
        get
        {
            if (uiCanvas == null)
            {
                initialize();
            }
            return uiCanvas;
        }
    }
    protected Transform UIRoot
    {
        get
        {
            return UICanvas.GetChild(0);
        }
    }
    protected Transform UIMain
    {
        get
        {
            return UICanvas.GetChild(1);
        }
    }
    protected Transform UIPop
    {
        get
        {
            return UICanvas.GetChild(2);
        }
    }
    protected Transform UIAlert
    {
        get
        {
            return UICanvas.GetChild(3);
        }
    }
    protected Transform UIStroy
    {
        get
        {
            return UICanvas.GetChild(4);
        }
    }
    protected Transform UILoad
    {
        get
        {
            return UICanvas.GetChild(5);
        }
    }


    public void initialize()
    {
        GameObject go = GameObject.Instantiate(Resources.Load(canvasPath)) as GameObject;
        uiCanvas = go.transform;
    }

    public static Transform getCanvas()
    {
        return Instance.UICanvas;
    }
    public static Transform getUIRoot()
    {
        return Instance.UIRoot;
    }
    public static Transform getUIMain()
    {
        return Instance.UIMain;
    }
    public static Transform getUIPop()
    {
        return Instance.UIPop;
    }
    public static Transform getUIAlert()
    {
        return Instance.UIAlert;
    }
    public static Transform getUIStroy()
    {
        return Instance.UIStroy;
    }
    public static Transform getUILoad()
    {
        return Instance.UILoad;
    }
    public static Transform getNode(int index)
    {
        return Instance.UICanvas.GetChild(index);
    }

}

