using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBundle
{
    private AssetBundle ab;
    public AssetBundle Ab
    {
        get
        {
            refCount++;
            return ab;
        }
    }
    private int refCount = 0;
    protected int RefCount
    {
        get
        {
            return refCount;
        }
        set
        {
            refCount = value;
            Debug.LogError("ab name: " + ab.name + "  ref count: " + RefCount);
        }
    }
    private string key;

    public TBundle(string key, AssetBundle ab)
    {
        this.ab = ab;
        this.key = key;
    }

    public void subRefCount(int count = 1)
    {
        RefCount = RefCount - count;
    }
    public void addRefCount(int count = 1)
    {
        RefCount = RefCount + count;
    }

    public void onDispose()
    {
        if (this.ab != null)
        {
            ab.Unload(false);
            ab = null;
        }
        if (refCount > 0)
        {
            Debug.LogError("卸载ab refCount " + RefCount);
        }
    }
}

//管理assetbundle
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

    private Dictionary<string, TBundle> bundlePool = null;

    public void initialize()
    {
        bundlePool = new Dictionary<string, TBundle>();
    }

    public static bool isHave(string url)
    {
        return Instance.bundlePool.ContainsKey(url);
    }

    private static string getName(string name)
    {
        if (name.EndsWith(".assetbundle"))
        {
            name = name.Replace(".assetbundle", "");
        }
        return name;
    }

    public static TBundle getBundle(string url)
    {
        url = getName(url);
        if (Instance.bundlePool.ContainsKey(url))
        {
            return Instance.bundlePool[url];
        }
        return null;
    }

    public static void addBundle(string url, AssetBundle ab)
    {
        url = getName(url);
        if (!Instance.bundlePool.ContainsKey(url))
        {
            TBundle tab = new TBundle(url, ab);
            Instance.bundlePool.Add(url, tab);
            tab.addRefCount();
        }
    }

    public static void releaseRef(string url, int count = 1)
    {
        url = getName(url);
        if (Instance.bundlePool.ContainsKey(url))
        {
            TBundle tab = Instance.bundlePool[url];
            tab.subRefCount(count);
        }
    }

    public static void addRef(string url, int count = 1)
    {
        url = getName(url);
        if (Instance.bundlePool.ContainsKey(url))
        {
            TBundle tab = Instance.bundlePool[url];
            tab.addRefCount(count);
        }
    }

    public static void clearAll()
    {
        Instance.onDispose();
    }

    public void onDispose()
    {
        var ier = bundlePool.GetEnumerator();
        while (ier.MoveNext())
        {
            ier.Current.Value.onDispose();
        }
        bundlePool.Clear();
    }

}
