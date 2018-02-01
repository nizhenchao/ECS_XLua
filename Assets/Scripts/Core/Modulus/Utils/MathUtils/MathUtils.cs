using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MathUtils
{
    /// <summary>
    /// 唯一ID
    /// </summary>
    public static int UniqueID
    {
        get
        {
            return BitConverter.ToInt32(Encoding.UTF8.GetBytes(System.Guid.NewGuid().ToString()), 0);
        }
    }

    /// <summary>
    /// 唯一ID
    /// </summary>
    public static long UniqueLID
    {
        get
        {
            return BitConverter.ToInt64(Encoding.UTF8.GetBytes(System.Guid.NewGuid().ToString()), 0);
        }
    }

}

