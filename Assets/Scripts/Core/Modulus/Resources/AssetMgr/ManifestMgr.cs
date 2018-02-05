using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ManifestMgr
{
    private static ManifestMgr instance;
    public static ManifestMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ManifestMgr();
            }
            return instance;
        }
    }

    private string suff = "Res/AssetBundle/AssetBundle";
    private AssetBundleManifest manifest = null;

    public void initialize()
    {
        //    LoaderThread.Instance.StartCoroutine(doLoad());
        loadManifest();
    }

    public static void getDepends(string name, ref List<string> lst)
    {
        if (!name.EndsWith(".assetbundle"))
        {
            name = name + ".assetbundle";
        }
        name = name.ToLower();
        if (Instance.manifest != null)
        {
            string[] deps = Instance.manifest.GetAllDependencies(name);
            for (int i = 0; i < deps.Length; i++)
            {
                lst.Add(deps[i]);
            }
        }
    }

    void loadManifest()
    {
        //LoadFromFile不可以有.assetbundle后缀
        var bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(Application.dataPath, suff));
        manifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        // 压缩包释放掉
        bundle.Unload(false);
        bundle = null;
    }

    IEnumerator doLoad()
    {
        //LoadFromFile不可以有.assetbundle后缀
        var bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(Application.dataPath, suff));
        yield return bundle;
        manifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        // 压缩包释放掉
        bundle.Unload(false);
        bundle = null;
    }
}

