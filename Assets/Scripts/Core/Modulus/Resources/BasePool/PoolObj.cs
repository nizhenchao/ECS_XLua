using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolObj : MonoBehaviour
{
    public E_PoolType pType;
    public string url;
    public List<string> depends = new List<string>();

    public void onDispose()
    {
        for (int i = 0; i < depends.Count; i++)
        {
            AssetMgr.releaseRef(depends[i], 1);
        }
        GameObject.Destroy(this.gameObject);
    }

}

