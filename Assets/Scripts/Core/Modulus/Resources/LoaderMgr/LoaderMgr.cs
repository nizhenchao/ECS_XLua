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

    public void addTask(string url, Action<string, bool, TBundle> call)
    {
        if (!dictTask.ContainsKey(url))
        {
            LoaderTask task = new LoaderTask(url, call);
            dictTask.Add(task.url, task);
        }
        else
        {
            dictTask[url].addHandler(call);            
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

