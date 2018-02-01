using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CSExtend
{
    [CSharpCallLua]
    public delegate void LuaEventName(string name);
    [CSharpCallLua]
    public delegate void ActionLoadCall(GameObject obj);
}
