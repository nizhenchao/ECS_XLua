using System;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUtils
{
    private static Vector3 fixScreen = Vector3.zero;
    public static Vector3 FixScreen
    {
        get
        {
            if (fixScreen == Vector3.zero)
            {
                initScreen();
            }
            return fixScreen;
        }
    }

    private static void initScreen()
    {
        fixScreen = new Vector3(Screen.width, Screen.height, 0);
    }



}

