using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//加载状态
public enum E_LoadStatus
{
    Wait,
    Loading,
    Finish,
    Fail,
}

//对象池
public enum E_PoolType
{
    None,
    UseTime,
    Level,
    Gobal,
}

public static class Define
{
    public static string On_Scene_Load_Begin = "On_Scene_Load_Begin";
    public static string On_Scene_Load_Finish = "On_Scene_Load_Finish";


}

