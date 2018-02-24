using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;
using DG.Tweening;
using DG;

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
    //获取两个向量的夹角
    public static float getVectorAngle(Vector2 to, Vector2 from)
    {
        return Vector2.Angle(from, to);
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
    //移除一个计时器
    public static void removeTimer(long uid)
    {
        TimerMgr.removeTimer(uid);
    }
    //时间戳 毫秒级别
    public static double getMillTimer() {
        return TimerUtils.getMillTimer();
    }
    //时间戳 秒级别
    public static double getSecTimer()
    {
        return TimerUtils.getSecTimer();
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
    public static float getAngle(Vector3 dir) {
        return Vector3.Angle(Vector3.forward, dir.normalized);
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
    public static GameObject getNodeByRecursion(GameObject root, string nodeName)
    {
        if (root != null)
        {
            return getNodeByTrans(root.transform, nodeName);
        }
        return null;
    }
    private static GameObject getNodeByTrans(Transform rootTrans, string nodeName)
    {
        if (rootTrans.gameObject.name == nodeName)
        {
            return rootTrans.gameObject;
        }
        int childCount = rootTrans.childCount;
        GameObject node = null;
        for (int i = 0; i < childCount; i++)
        {
            node = getNodeByTrans(rootTrans.GetChild(i), nodeName);
            if (node != null)
            {
                return node;
            }
        }
        return null;
    }
    //添加UI事件监听脚本
    public static EventListener addEventListener(GameObject obj)
    {
        EventListener listener = null;
        if (obj != null)
        {
            listener = obj.GetComponent<EventListener>();
            if (listener == null)
            {
                listener = obj.AddComponent<EventListener>();
            }
        }
        return listener;
    }

    //设置UI的material属性
    public static void setMaterialFloat(Image img, string key, float val)
    {
        if (img != null)
        {
            img.material.SetFloat(key, val);
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

    //moveto v3
    public static Tweener doLocalMoveTo(GameObject obj, float dur, Vector3 end, TweenCallback call = null, float delay = 0)
    {
        Tweener tw = null;
        if (obj != null)
        {
            tw = obj.transform.DOLocalMove(end, dur).SetDelay(delay);
            if (call != null)
            {
                tw.OnComplete(call);
            }
        }
        return tw;
    }

    //do float Tweener To(DOSetter<float> setter, float startValue, float endValue, float duration);
    public static Tweener doFloatTo(DG.Tweening.Core.DOSetter<float> call, float startValue, float endValue, float duration,TweenCallback finish=null)
    {
        Tweener tw = null;
        tw = DOTween.To(call, startValue, endValue, duration);
        if (finish != null) {
            tw.OnComplete(finish);
        }
        return tw;
    }


    //销毁tweener
    public static void killTweener(Tweener tw, bool doComplete = false)
    {
        if (tw != null)
        {
            tw.Kill(doComplete);
        }
    }
    //旋转tween
    public static void lerpRotation(GameObject obj, float angle)
    {
        if (obj != null)
        {
            obj.transform.DORotate(new Vector3(0, angle, 0), 0.1f);
        }
    }
    #endregion


    #region 摄像机相关
    public static void setCameraPlayer(GameObject player)
    {
        if (player == null)
        {
            return;
        }
        GameObject parent = null;
        MainCameraWidget mw = null;
        if (GameObject.FindGameObjectWithTag("PlayerCamera") != null)
        {
            parent = GameObject.FindGameObjectWithTag("PlayerCamera");
        }
        else
        {
            Camera main = Camera.main;
            if (main == null)
            {
                main = new Camera();
                main.tag = "Main Camera";
            }

            if (main != null)
            {
                parent = new GameObject("PlayerCamera");
                parent.tag = "PlayerCamera";
                main.transform.SetParent(parent.transform);
                main.transform.localPosition = Vector3.zero;
                main.transform.localEulerAngles = Vector3.zero;
                main.transform.localScale = Vector3.one;
            }
        }

        if (parent != null)
        {
            mw = parent.gameObject.GetComponent<MainCameraWidget>();
            if (mw == null)
            {
                mw = parent.gameObject.AddComponent<MainCameraWidget>();
            }
        }
        if (mw != null)
        {
            mw.setFollow(player);
        }
    }
    public static void doShake(float time, float att, float hor, float ver)
    {
        GameObject camera = GameObject.FindGameObjectWithTag("PlayerCamera");
        if (camera != null)
        {
            MainCameraWidget mw = camera.gameObject.GetComponent<MainCameraWidget>();
            if (mw != null)
            {
                mw.doShake(time, att, hor, ver);
            }
        }
    }
    #endregion
}
