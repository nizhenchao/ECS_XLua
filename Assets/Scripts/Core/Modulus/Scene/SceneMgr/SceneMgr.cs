using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr
{
    private static SceneMgr instance;
    public static SceneMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SceneMgr();
            }
            return instance;
        }
    }
    public void initialize()
    {

    }

    IEnumerator doLoad(string level, Action<string, bool, Scene> callBack, Action<float> progress = null)
    {
        CSCallMgr.Instance.sendLuaMsg(Define.On_Scene_Load_Begin);
        AsyncOperation aop = SceneManager.LoadSceneAsync(level);
        do
        {
            yield return new WaitForEndOfFrame();
            if (aop == null)
            {
                if (callBack != null)
                {
                    callBack("加载场景失败 sceneName " + level, false, new Scene());
                }
                yield break;
            }
            if (progress != null)
            {
                progress(aop.progress);
            }            
        } while (!aop.isDone);
        CSCallMgr.Instance.sendLuaMsg(Define.On_Scene_Load_Finish);
    }


    #region 提供静态方法
    public static void loadScene(string level, Action<string, bool, Scene> callBack, Action<float> progress = null)
    {
        LoaderThread.Instance.StartCoroutine(Instance.doLoad(level, callBack, progress));
    }
    public static void loadScene(string level, Action<float> progress = null)
    {
        LoaderThread.Instance.StartCoroutine(Instance.doLoad(level, null, progress));
    }
    #endregion
}

