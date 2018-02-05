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
            Debug.Log("ab name: " + ab.name + "  ref count:<color=red> " + RefCount+"</color>");
            if (RefCount <= 0)
            {
                AssetMgr.disposeBundle(key);               
            }
        }
    }
    private string key;
    //private float useTime = -1;

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

    public void isAlive()
    {

    }

    public void onDispose()
    {
        if (this.ab != null)
        {
            ab.Unload(false);
            ab = null;
            Resources.UnloadUnusedAssets();
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

    private void onTick(int count)
    {

    }

    private string getName(string name)
    {
        if (name.EndsWith(".assetbundle"))
        {
            name = name.Replace(".assetbundle", "");
        }
        return name;
    }
    //是否包含bundle
    private bool isHaveBundle(string url)
    {
        url = getName(url);
        return bundlePool.ContainsKey(url);
    }
    //获取一个ab 返回封装过的TBundle
    private TBundle getAssetBundle(string url)
    {
        url = getName(url);
        if (bundlePool.ContainsKey(url))
        {
            return bundlePool[url];
        }
        return null;
    }
    //添加一个ab
    private void addAssetBundle(string url, AssetBundle ab)
    {        
        url = getName(url);
        if (!bundlePool.ContainsKey(url))
        {
            TBundle tab = new TBundle(url, ab);
            bundlePool.Add(url, tab);
        }
    }
    //释放一个bundle引用
    private void releaseBundleRef(string url, int count = 1)
    {
        url = getName(url);
        if (bundlePool.ContainsKey(url))
        {
            TBundle tab = bundlePool[url];
            tab.subRefCount(count);
        }
    }
    //添加一个Bundle引用
    private void addBundleRef(string url, int count = 1)
    {
        url = getName(url);
        if (bundlePool.ContainsKey(url))
        {
            TBundle tab = bundlePool[url];
            tab.addRefCount(count);
        }
    }
    //释放一个ab
    private void disposeAssetBundle(string url)
    {
        url = getName(url);
        if (bundlePool.ContainsKey(url))
        {
            TBundle tb = bundlePool[url];
            bundlePool.Remove(url);
            tb.onDispose();
        }
    }
    //释放所有ab
    public void onDispose()
    {
        var ier = bundlePool.GetEnumerator();
        while (ier.MoveNext())
        {
            ier.Current.Value.onDispose();
        }
        bundlePool.Clear();
    }


    #region 提供静态方法
    /// <summary>
    /// 是否有
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static bool isHave(string url)
    {
        return Instance.isHaveBundle(url);
    }

    /// <summary>
    /// 获取bundle
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static TBundle getBundle(string url)
    {
        return Instance.getAssetBundle(url);
    }

    public static void addBundle(string url, AssetBundle ab)
    {
        Instance.addAssetBundle(url, ab);
    }

    public static void releaseRef(string url, int count = 1)
    {
        Instance.releaseBundleRef(url, count);
    }

    public static void addRef(string url, int count = 1)
    {
        Instance.addBundleRef(url, count);
    }

    public static void disposeBundle(string url) {
        Instance.disposeAssetBundle(url);
    }

    public static void clearAll()
    {
        Instance.onDispose();
    }
    #endregion

}
