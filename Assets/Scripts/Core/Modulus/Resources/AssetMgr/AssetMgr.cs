using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//管理asset
public class AssetMgr
{
    private static AssetMgr instance;
    public static AssetMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AssetMgr();
            }
            return instance;
        }
    }

    private Dictionary<string, AssetBundle> dictBundle = null;

    public void initialize()
    {
        dictBundle = new Dictionary<string, AssetBundle>();
    }


    public static bool isHave(string url)
    {
        return Instance.dictBundle.ContainsKey(url);
    }

    public static AssetBundle getBundle(string url)
    {
        if (Instance.dictBundle.ContainsKey(url))
        {
            return Instance.dictBundle[url];
        }
        return null;
    }

    public static void addBundle(string url, AssetBundle ab)
    {
        if (!Instance.dictBundle.ContainsKey(url))
        {
            Instance.dictBundle.Add(url, ab);
        }
    }

    public void onDispose()
    {

    }

}
