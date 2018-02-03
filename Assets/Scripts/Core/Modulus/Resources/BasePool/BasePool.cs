using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//对象池基类
public class BasePool
{
    private Transform root;//池子节点
    private PoolObj tempObj = null;//模版Obj
    private double usingTime = -1;//usetime
    private E_PoolType pType;//对象池类型
    public E_PoolType PType
    {
        get
        {
            return this.pType;
        }
        set
        {
            pType = value;
            usingTime = TimerUtils.getSecTimer();
        }
    }//对象池类型    
    public bool IsAlive
    {
        get
        {
            return TimerUtils.getSecTimer() - usingTime < 10;
        }
    }//时间池子生命
    private string url;//池子url
    private List<PoolObj> objLst = new List<PoolObj>();//缓存obj
    private List<Action<GameObject>> loadHandler = new List<Action<GameObject>>();//缓存正在加载回调
    private List<string> depends = new List<string>();//依赖

    public BasePool(string url, E_PoolType pt)
    {
        this.url = url;
        this.PType = pt;
        string name = "[{0}][{1}][{2}]";
        name = string.Format(name, "root", pt.ToString(), url.ToString());
        GameObject go = new GameObject(name);
        root = go.transform;
        ManifestMgr.getDepends(url, ref depends);
        root.SetParent(PoolMgr.Instance.PoolRoot);
    }

    public void getObj(Action<GameObject> callBack)
    {
        //从未加载过
        if (tempObj == null)
        {
            loadHandler.Add(callBack);
            LoaderTask loader = new LoaderTask(url, onLoaderFinish);
            LoaderMgr.Instance.addTask(loader);
        }
        else
        {
            GameObject go = getInsObj();
            callBack(go);
        }
    }

    private void onLoaderFinish(string result, bool isSucc, GameObject temp)
    {
        if (isSucc)
        {
            temp.name = temp.name.Replace("(Clone)", "");
            temp.transform.SetParent(root);
            temp.transform.localPosition = new Vector3(2000, 2000, 2000);
            tempObj = temp.AddComponent<PoolObj>();
            tempObj.Obj = temp;
            tempObj.pType = pType;
            tempObj.url = url;
            tempObj.depends = this.depends;
            tempObj.onInit();
            for (int i = 0; i < loadHandler.Count; i++)
            {
                GameObject go = getInsObj();
                loadHandler[i](go);
            }
            loadHandler.Clear();
        }
    }

    private GameObject getInsObj()
    {
        GameObject go = null;
        if (objLst.Count <= 0)
        {
            if (tempObj.Obj == null)
            {
                Debug.LogError("<color=yellow> tempObj.Obj == null</color>");
            }
            go = GameObject.Instantiate(tempObj.Obj);
            PoolObj po = go.GetComponent<PoolObj>();
            if (po == null)
            {
                po = go.AddComponent<PoolObj>();
            }
            po.pType = pType;
            po.url = url;
            po.depends = this.depends;
            po.onInit();
        }
        else
        {
            go = objLst[0].Obj;
            objLst.RemoveAt(0);
        }
        go.transform.SetParent(null);
        go.transform.position = Vector3.zero;
        go.transform.localScale = Vector3.one;
        usingTime = TimerUtils.getSecTimer();
        return go;
    }

    public void saveObj(PoolObj po)
    {
        GameObject go = po.Obj;
        go.transform.SetParent(root);
        go.transform.localPosition = Vector3.zero;
        objLst.Add(po);
    }

    public void onDispose()
    {
        loadHandler.Clear();
        loadHandler = null;
        for (int i = 0; i < objLst.Count; i++)
        {
            objLst[i].onDispose();
        }
        objLst.Clear();
        objLst = null;
        tempObj.onDispose();
        tempObj = null;
        GameObject.Destroy(this.root.gameObject);
        Debug.Log("CS basePool 释放");
    }
}

