using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ResMgr
{
    private static ResMgr instacne;
    public static ResMgr Instance
    {
        get
        {
            if (instacne == null)
            {
                instacne = new ResMgr();
            }
            return instacne;
        }
    }

    public void initialize()
    {
        GameObject go = new GameObject("_loaderThread");
        go.AddComponent<LoaderThread>();
        AssetMgr.Instance.initialize();
    }

    //需要再封装一层 提供完整url PoolType
    public void getObj(string url, Action<GameObject> callBack, E_PoolType pType = E_PoolType.UseTime)
    {
        PoolMgr.Instance.getObj(url, callBack, pType);
    }

    public void desObj(GameObject go)
    {
        PoolMgr.Instance.saveObj(go);
    }


}

