using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PoolMgr
{
    private static PoolMgr instance;
    public static PoolMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PoolMgr();
            }
            return instance;
        }
    }
    private Transform poolRoot = null;
    public Transform PoolRoot
    {
        get
        {
            if (poolRoot == null)
            {
                GameObject go = new GameObject("_poolRoot");
                poolRoot = go.transform;
                GameObject.DontDestroyOnLoad(go);
            }
            return poolRoot;
        }
    }

    public void initialize()
    {
        TimerMgr.addEveryMillHandler(checkUseTime, 15000);
    }

    public Dictionary<string, BasePool> pools = new Dictionary<string, BasePool>();

    //从对象池取出
    public void getObj(string url, Action<GameObject> callBack, E_PoolType pType)
    {
        if (!pools.ContainsKey(url))
        {
            BasePool bp = new BasePool(url, pType);
            pools.Add(url, bp);
        }
        pools[url].getObj(callBack);
    }

    //放回
    public void saveObj(GameObject go)
    {
        PoolObj po = go.GetComponent<PoolObj>();
        bool isDestroy = po == null && !pools.ContainsKey(po.url);
        if (isDestroy)
        {
            GameObject.Destroy(go, 0.3f);
        }
        else
        {
            pools[po.url].saveObj(go);
        }
    }


    public void checkUseTime(int count)
    {
        disposeUseTime();
    }

    //释放时间池子
    public void disposeUseTime()
    {
        List<string> keys = new List<string>();
        var ier = pools.GetEnumerator();
        while (ier.MoveNext())
        {
            if (!ier.Current.Value.IsAlive)
            {
                keys.Add(ier.Current.Key);
            }
        }
        for (int i = 0; i < keys.Count; i++)
        {
            if (pools.ContainsKey(keys[i]))
            {
                BasePool bp = pools[keys[i]];
                pools.Remove(keys[i]);
                bp.onDispose();
            }
        }

    }
    //释放关卡池子
    public void disposeLevel()
    {
        List<string> keys = new List<string>();
        var ier = pools.GetEnumerator();
        while (ier.MoveNext())
        {
            if (ier.Current.Value.PType == E_PoolType.Level)
            {
                keys.Add(ier.Current.Key);
            }
        }
        for (int i = 0; i < keys.Count; i++)
        {
            if (pools.ContainsKey(keys[i]))
            {
                pools.Remove(keys[i]);
            }
        }
        keys.Clear();
    }
    public void disGlobal()
    {

    }


}

