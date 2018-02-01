using System;
using System.Collections.Generic;

public class EveryTimeHandler : BaseTimeHandler
{
    public EveryTimeHandler(int end, Action<int> eh, Action<int> ch = null, int inter = 1) : base(end, eh, ch, inter)
    {
    }

    public override void check(double now)
    {
        if (now - startTime > interval && !Invalid)
        {
            nowCount++;
            if (eHandler != null)
            {
                eHandler(nowCount);
            }
        }
    }
}

