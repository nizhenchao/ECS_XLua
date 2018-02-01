using System;
using System.Collections.Generic;

public class FixedTimePool
{
    private Dictionary<long, BaseTimeHandler> fixedPool = new Dictionary<long, BaseTimeHandler>();
    private List<long> removeLst = new List<long>();

    public void addTimer(long id, BaseTimeHandler handler)
    {
        fixedPool.Add(id, handler);
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
        if (fixedPool.Count <= 0) return;
        for (int i = 0; i < removeLst.Count; i++)
        {
            if (fixedPool.ContainsKey(removeLst[i]))
            {
                BaseTimeHandler h = fixedPool[removeLst[i]];
                fixedPool.Remove(removeLst[i]);
                h.onDispose();
            }
        }

        var ier = fixedPool.GetEnumerator();
        while (ier.MoveNext())
        {
            ier.Current.Value.check(nowTime);
        }
    }
}

