using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class LoaderTask
{
    public E_LoadStatus status = E_LoadStatus.Wait;
    public string url;
    public Action<string, bool, GameObject> callBack;
    string path =
#if UNITY_ANDROID
		"jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE
		Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
    "file://" + Application.dataPath;
#else
        string.Empty;
#endif        

    public LoaderTask(string url, Action<string, bool, GameObject> call)
    {
        this.url = url;
        this.callBack = call;
    }

    public void doLoad()
    {
#if UNITY_EDITOR && TWL_DEVELOP
        LoaderThread.Instance.StartCoroutine(wwwLoad());
#else
        LoaderThread.Instance.StartCoroutine(wwwLoad());
#endif
    }
    //编辑器下面使用res load
    IEnumerator onLoad()
    {
        status = E_LoadStatus.Loading;
        if (string.IsNullOrEmpty(url))
        {
            status = E_LoadStatus.Fail;
            yield break;
        }
        ResourceRequest req = Resources.LoadAsync(url);
        while (!req.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        UnityEngine.Object obj = req.asset;
        if (callBack != null)
        {
            GameObject go = GameObject.Instantiate(obj) as GameObject;
            callBack("res.load加载成功", true, go);
        }
        status = E_LoadStatus.Finish;
    }

    //www load
    IEnumerator wwwLoad()
    {
        Debug.Log("加载资源" + url);
        status = E_LoadStatus.Loading;
        if (string.IsNullOrEmpty(url))
        {
            status = E_LoadStatus.Fail;
            yield break;
        }
        //是否已经存在ab
        if (AssetMgr.isHave(url))
        {
            TBundle tb = AssetMgr.getBundle(url);
            UnityEngine.Object aobj = tb.Ab.LoadAsset(getAbName(url));
            if (callBack != null)
            {
                GameObject go = GameObject.Instantiate(aobj) as GameObject;
                callBack("AssetMgr缓存加载成功", true, go);
                tb.addRefCount();
            }
            status = E_LoadStatus.Finish;
            yield break;
        }
        //先加载所有依赖
        List<string> depends = new List<string>();
        ManifestMgr.getDepends(url, ref depends);
        if (depends != null)
        {
            for (int i = 0; i < depends.Count; i++)
            {
                string key = depends[i].Replace(".assetbundle", "");
                if (!AssetMgr.isHave(key))
                {
                    AssetBundle ab = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "Res/AssetBundle/" + depends[i]));
                    AssetMgr.addBundle(key, ab);
                }
                yield return new WaitForEndOfFrame();
            }
        }
        //加载资源
        AssetBundle objAb = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "Res/AssetBundle/" + url + ".assetbundle"));
        yield return objAb;
        AssetMgr.addBundle(url, objAb);
        UnityEngine.Object obj = objAb.LoadAsset(getAbName(url));
        if (callBack != null)
        {
            GameObject go = GameObject.Instantiate(obj) as GameObject;
            callBack("LoadFromFile加载成功", true, go);
        }
        status = E_LoadStatus.Finish;
    }

    private string getAbName(string id)
    {
        string realName = "";
        int ind = id.LastIndexOf("/");
        if (ind >= 0)
        {
            realName = id.Substring(ind + 1, id.Length - ind - 1);
        }
        else
        {
            realName = id;
        }
        return realName;
    }
}