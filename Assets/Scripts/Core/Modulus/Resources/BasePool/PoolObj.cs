using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolObj : MonoBehaviour
{
    public E_PoolType pType;
    public string url;
    public List<string> depends = new List<string>();

    private GameObject obj = null;
    public GameObject Obj
    {
        get
        {
            if (obj == null)
            {
                obj = this.gameObject;
            }
            return obj;
        }
        set
        {
            obj = value;
        }
    }

    public void onInit()
    {
        for (int i = 0; i < depends.Count; i++)
        {
            AssetMgr.addRef(depends[i], 1);
        }
        AssetMgr.addRef(url, 1);
    }

    public void onDispose()
    {
        for (int i = 0; i < depends.Count; i++)
        {
            AssetMgr.releaseRef(depends[i], 1);
        }
        AssetMgr.releaseRef(url, 1);
        Obj = null;
        GameObject.Destroy(this.gameObject);
    }

}

