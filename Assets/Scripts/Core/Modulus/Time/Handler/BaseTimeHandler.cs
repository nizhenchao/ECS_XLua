using System;
using System.Collections.Generic;

public class BaseTimeHandler
{
    protected double startTime = -1;
    protected int endTime = -1;
    protected float interval = -1;
    protected Action<int> eHandler = null;
    protected Action<int> cHandler = null;
    protected bool invalid = false;
    public bool Invalid
    {
        get
        {
            return invalid;
        }
    }
    protected int nowCount = 0;

    public BaseTimeHandler(int end, Action<int> eh, Action<int> ch = null, int inter = 1)
    {
        startTime = TimerUtils.getMillTimer();
        endTime = end;
        cHandler = ch;
        eHandler = eh;
        interval = inter;
        initialize();
    }

    protected virtual void initialize()
    {

    }

    public virtual void check(double now)
    {
        if (now - startTime > interval && !Invalid)
        {
            nowCount++;
            if (eHandler != null)
            {
                eHandler(nowCount);
            }
            if (nowCount >= endTime)
            {
                if (cHandler != null)
                {
                    cHandler(nowCount);
                }
                invalid = true;
            }
            startTime = now;
        }
    }

    public void onDispose()
    {
        eHandler = null;
        cHandler = null;
    }

}

