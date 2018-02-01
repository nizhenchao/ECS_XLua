using System;
using System.Collections.Generic;

public class NormalTimePool
{
    private Dictionary<long, BaseTimeHandler> normalPool = new Dictionary<long, BaseTimeHandler>();
    private List<long> removeLst = new List<long>();


    public void addTimer(long id, BaseTimeHandler handler)
    {
        normalPool.Add(id, handler);
    }

    public void removeKey(long id)
    {
        if (!removeLst.Contains(id))
        {
            removeLst.Add(id);
        }
    }

    public void clear()
    {

    }

    public void doCheck(double nowTime)
    {
        if (normalPool.Count <= 0) return;
        for (int i = 0; i < removeLst.Count; i++)
        {
            if (normalPool.ContainsKey(removeLst[i]))
            {
                BaseTimeHandler h = normalPool[removeLst[i]];
                normalPool.Remove(removeLst[i]);
                h.onDispose();
            }
        }

        var ier = normalPool.GetEnumerator();
        while (ier.MoveNext())
        {
            if (ier.Current.Value.Invalid)
            {
                removeKey(ier.Current.Key);
            }
            else
            {
                ier.Current.Value.check(nowTime);
            }
        }
    }
}

