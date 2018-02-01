using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimerUtils
{
    static private System.DateTime startTime;
    static private int timeId;
    static private System.Object lockObj;

    static TimerUtils()
    {
        lockObj = new object();
        startTime = new System.DateTime(1970, 1, 1);
    }

    public static double getMillTimer()
    {
        TimeSpan ts = DateTime.UtcNow - startTime;
        return ts.TotalMilliseconds;     //精确到毫秒
    }

    public static double getSecTimer()
    {
        TimeSpan ts = DateTime.UtcNow - startTime;
        return ts.TotalSeconds;     //精确到秒
    }
    static public int getTimeId()
    {
        lock (lockObj)
        {
            return ++timeId;
        }
    }
}

