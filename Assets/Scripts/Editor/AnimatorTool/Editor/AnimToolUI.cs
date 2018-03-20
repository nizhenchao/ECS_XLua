using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimToolUI : EditorWindow
{
    private static AnimToolUI _instance = null;

    [MenuItem("ToolsWindow/AnimTools")]
    public static void showWindow() {
        if (_instance == null) {
            _instance = (AnimToolUI)EditorWindow.GetWindow(typeof(AnimToolUI), false, "动画编辑器", true);
            _instance.maxSize = new Vector2(1280, 720);
        }
    }



}
