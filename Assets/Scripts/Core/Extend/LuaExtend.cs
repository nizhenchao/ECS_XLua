using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;
using DG.Tweening;

/// <summary>
/// 导出接口到Lua
/// </summary>
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

    #region 优化Lua CS调用相关(操作GameObject)
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
    public static void setActive(GameObject obj, bool isActive)
    {
        if (obj != null)
        {
            obj.SetActive(isActive);
        }
    }
    //rotation angle scale todo
    #endregion

    #region UI相关
    //设置UI在Canvas节点
    public static void setUINode(GameObject uiObj, int node)
    {
        uiObj.transform.SetParent(UIMgr.getNode(node));
        uiObj.transform.localPosition = Vector3.zero;
        uiObj.transform.localScale = Vector3.one;
    }
    //设置Image sprite
    public static void setSprite(GameObject obj, string name)
    {
        AtlasMgr.setSprite(obj.GetComponent<Image>(), name);
    }
    //获取UI下面的一个节点
    public static GameObject getNode(GameObject root, string path)
    {
        if (root != null)
            return root.transform.Find(path).gameObject;
        else
            return null;
    }
    //递归查找UI下面的一个节点
    public static GameObject getNodeByRecursion(GameObject root, string nodeName) {
        if (root != null) {
            return getNodeByTrans(root.transform, nodeName);
        }
        return null;
    }
    private static GameObject getNodeByTrans(Transform rootTrans,string nodeName) {
        if (rootTrans.gameObject.name == nodeName) {
            return rootTrans.gameObject;
        }
        int childCount = rootTrans.childCount;
        GameObject node = null;
        for (int i = 0; i < childCount; i++)
        {
            node =  getNodeByTrans(rootTrans.GetChild(i), nodeName);
            if (node != null) {
                return node;
            }
        }
        return null;
    }

    //UI添加一个点击监听
    public static void addClickHandler(GameObject obj, Action handler = null)
    {
        if (obj != null)
        {
            EventListener lis = obj.GetComponent<EventListener>();
            if (lis == null)
            {
                lis = obj.AddComponent<EventListener>();
            }
            lis.setClickHandler(handler);
        }
    }

    #endregion

    #region doTween导出相关
    //缩放动画
    public static Tweener doUpDownScaleAnim(GameObject obj, string title = null, Action onFinish = null)
    {
        Tweener tw = null;
        if (obj != null)
        {
            obj.transform.localScale = new Vector3(1, 0, 1);
            obj.GetComponentInChildren<Text>().gameObject.transform.localScale = new Vector3(0, 1, 1);
            tw = obj.transform.DOScaleY(1, 0.3f).OnComplete(() =>
            {
                if (obj.GetComponentInChildren<Text>() != null)
                {
                    obj.GetComponentInChildren<Text>().text = title;
                    obj.GetComponentInChildren<Text>().gameObject.transform.DOScaleX(1, 0.15f);
                }
                obj.transform.DOScaleY(0, 0.3f).SetDelay(1.2f).OnComplete(() => { if (onFinish != null) onFinish.Invoke(); });
            });
        }
        return tw;
    }

    public static void killTweener(Tweener tw, bool doComplete = false)
    {
        if (tw != null)
        {
            tw.Kill(doComplete);
        }
    }

    #endregion

}
