using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class MyTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(loadByWWW());
    }


    IEnumerator loadByWWW()
    {
        int lastKb = 0;
        WWW www = new WWW("http://ynnx.sg.ufileos.com/patch/1_2.zip");
        while (!www.isDone) {
            yield return new WaitForSeconds(1);
            int mb = (www.bytesDownloaded / 1024) ;
            Debug.Log("每秒kb :  " + (mb- lastKb));
            lastKb = mb;
        }
        yield return www;

    }

}
