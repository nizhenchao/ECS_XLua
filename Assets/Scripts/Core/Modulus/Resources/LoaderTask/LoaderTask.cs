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
    public List<Action<string, bool, TBundle>> handlerLst = new List<Action<string, bool, TBundle>>();

    public LoaderTask(string url, Action<string, bool, TBundle> call)
    {
        this.url = url;
        addHandler(call);
    }

    public void addHandler(Action<string, bool, TBundle> call)
    {
        if (call != null)
            handlerLst.Add(call);
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
        //if (callBack != null)
        //{
        //    GameObject go = GameObject.Instantiate(obj) as GameObject;
        //    //  callBack("res.load加载成功", true, go);
        //}
        status = E_LoadStatus.Finish;
    }

    //www load
    IEnumerator wwwLoad()
    {
        //Debug.Log("加载资源" + url);
        status = E_LoadStatus.Loading;
        if (string.IsNullOrEmpty(url))
        {
            status = E_LoadStatus.Fail;
            yield break;
        }
        //是否已经存在ab
        if (AssetMgr.isHave(url))
        {
            for (int i = 0; i < handlerLst.Count; i++)
            {
                handlerLst[i].Invoke(url, true, AssetMgr.getBundle(url));
            }
            status = E_LoadStatus.Finish;
            yield break;
        }

        //加载资源
        AssetBundleCreateRequest abReq = AssetBundle.LoadFromFileAsync(Path.Combine(Application.dataPath, "Res/AssetBundle/" + url + ".assetbundle"));
        do
        {
            if (abReq.assetBundle == null)
            {
                status = E_LoadStatus.Fail;
                yield break;
            }
            yield return new WaitForEndOfFrame();
        } while (!abReq.isDone);
        AssetMgr.addBundle(url, abReq.assetBundle);
        for (int i = 0; i < handlerLst.Count; i++)
        {
            handlerLst[i].Invoke(url, true, AssetMgr.getBundle(url));
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