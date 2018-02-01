using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LoaderMgr
{

    private static LoaderMgr instance;
    public static LoaderMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoaderMgr();
            }
            return instance;
        }
    }

    public void initialize()
    {
        TimerMgr.addEveryMillHandler(onTick, 50);
    }

    private List<string> removeLst = new List<string>();
    private Dictionary<string, LoaderTask> dictTask = new Dictionary<string, LoaderTask>();

    public void addTask(LoaderTask task)
    {
        if (!dictTask.ContainsKey(task.url))
        {
            dictTask.Add(task.url, task);
        }
        else
        {
            UnityEngine.Debug.LogError("同样的加载任务 url " + task.url);
        }
    }

    private void removeTask(string url)
    {
        if (!removeLst.Contains(url))
            removeLst.Add(url);
    }

    public void onTick(int count)
    {
        for (int i = 0; i < removeLst.Count; i++)
        {
            if (dictTask.ContainsKey(removeLst[i]))
            {
                dictTask.Remove(removeLst[i]);
            }
        }
        removeLst.Clear();
        var ier = dictTask.GetEnumerator();
        while (ier.MoveNext())
        {
            if (ier.Current.Value.status == E_LoadStatus.Wait)
                ier.Current.Value.doLoad();
            else
                removeTask(ier.Current.Value.url);
        }
    }



}

