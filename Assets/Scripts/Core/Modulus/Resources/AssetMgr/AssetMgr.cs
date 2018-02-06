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
            //Debug.Log("ab name: " + ab.name + "  ref count:<color=red> " + RefCount + "</color>");
            if (RefCount <= 0)
            {
                AssetMgr.disposeBundle(key);
            }
        }
    }
    private string key;
    private E_AssetType aType = E_AssetType.Normal;
    public E_AssetType AType
    {
        get
        {
            return aType;
        }
    }
    private double useTime = -1;
    private int lifeTime = 60;

    public TBundle(string key, AssetBundle ab)
    {
        this.ab = ab;
        this.key = key;
        if (this.key.StartsWith("atlas/"))
        {
            aType = E_AssetType.Atlas;
            useTime = TimerUtils.getSecTimer();
        }
    }

    public void subRefCount(int count = 1)
    {
        RefCount = RefCount - count;
    }
    public void addRefCount(int count = 1)
    {
        RefCount = RefCount + count;
    }

    public bool isAlive()
    {
        return TimerUtils.getSecTimer() - useTime <= lifeTime;
    }

    public void onDispose(bool isUnloadAll = false)
    {
        if (this.ab != null)
        {
            ab.Unload(isUnloadAll);
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
    private List<string> removeLst = null;

    public void initialize()
    {
        bundlePool = new Dictionary<string, TBundle>();
        removeLst = new List<string>();
        TimerMgr.addEveryMillHandler(onTick, 60000);
    }

    private void onTick(int count)
    {
        if (bundlePool.Count <= 0) return;
        var ier = bundlePool.GetEnumerator();
        removeLst.Clear();
        while (ier.MoveNext())
        {
            if (ier.Current.Value.AType == E_AssetType.Atlas)
            {
                if (!ier.Current.Value.isAlive())
                {
                    removeLst.Add(ier.Current.Key);
                }
            }
        }
        for (int i = 0; i < removeLst.Count; i++)
        {
            TBundle tb = bundlePool[removeLst[i]];
            bundlePool.Remove(removeLst[i]);
            tb.onDispose();
        }
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

    public static void disposeBundle(string url)
    {
        Instance.disposeAssetBundle(url);
    }

    public static void clearAll()
    {
        Instance.onDispose();
    }
    #endregion

}
