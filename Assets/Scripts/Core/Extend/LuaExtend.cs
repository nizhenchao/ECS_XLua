using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[LuaCallCSharp]
public static class LuaExtend
{
    #region 数学库相关
    //uid
    public static long getLUID()
    {
        return MathUtils.UniqueLID;
    }
    //uid
    public static int getSUID()
    {
        return MathUtils.UniqueID;
    }
    #endregion

    #region 资源加载 管理相关
    //加载资源
    public static void loadObj(string url, Action<GameObject> callBack)
    {
        ResMgr.Instance.getObj(url, callBack);
    }
    //销毁资源
    public static void destroyObj(GameObject obj)
    {
        ResMgr.Instance.desObj(obj);
    }
    #endregion

    #region 场景相关
    //场景加载
    public static void loadScene(string level, Action<float> progress = null)
    {
        SceneMgr.loadScene(level, progress);
    }
    #endregion

    #region 计时器相关
    public static long addMillHandler(int endCount, Action<int> eHandler, Action<int> cHandler = null, int interval = 1)
    {
        return TimerMgr.addMillHandler(endCount, eHandler, cHandler, interval);
    }
    public static long addSecHandler(int endCount, Action<int> eHandler, Action<int> cHandler = null, int interval = 1)
    {
        return TimerMgr.addSecHandler(endCount, eHandler, cHandler, interval);
    }
    public static long addMinHandler(int endCount, Action<int> eHandler, Action<int> cHandler = null, int interval = 1)
    {
        return TimerMgr.addMinHandler(endCount, eHandler, cHandler, interval);
    }
    public static long addEveryMillHandler(Action<int> eHandler, int interval = 1)
    {
        return TimerMgr.addEveryMillHandler(eHandler, interval);
    }
    public static void removeTimer(long uid)
    {

    }
    #endregion

    #region 优化Lua CS调用相关
    /// <summary>
    /// 多使用这种方式 效率最快
    /// </summary>
    /// <param name="go"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public static void setObjPos(GameObject go, float x, float y, float z)
    {
        setObjPos(go, new Vector3(x, y, z));
    }
    //Lua直接传V3 在Lua new V3会进行多次数据类型转换
    public static void setObjPos(GameObject go, Vector3 pos)
    {
        if (go != null)
        {
            go.transform.localPosition = pos;
        }
    }
    //rotation angle scale todo
    #endregion

    #region UI相关
    public static void setUINode(GameObject uiObj, int node)
    {
        uiObj.transform.SetParent(UIMgr.getNode(node));
        uiObj.transform.localPosition = Vector3.zero;
        uiObj.transform.localScale = Vector3.one;
    }

    public static void setSprite(GameObject obj, string name)
    {
        AtlasMgr.setSprite(obj.GetComponent<Image>(), name);
    }

    public static GameObject getNode(GameObject obj, string path)
    {
        return obj.transform.Find(path).gameObject;
    }
    #endregion

}
