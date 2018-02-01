using System;
using System.Collections;
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
        LoaderThread.Instance.StartCoroutine(doLoad());
    }

    public static string[] getDepends(string name) {
        if (Instance.manifest == null)
        {
            return null;
        }
        else {
            return Instance.manifest.GetAllDependencies(name);
        }
    }

    IEnumerator doLoad()
    {
        var bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(Application.dataPath, suff));
        yield return bundle;
        manifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        // 压缩包释放掉
        bundle.Unload(false);
        bundle = null;
    }
}

