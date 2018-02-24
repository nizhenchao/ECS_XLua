using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TestSp : MonoBehaviour {

    public GameObject prefabs;
	// Use this for initialization
	void Start () {
        Vector3 v3 = new Vector3(10, 0, 10);
        Debug.Log(Vector3.Angle(Vector3.forward,v3));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator OnClick()
    {
        
        Resources.UnloadUnusedAssets();//清干净以免影响测试效果

        yield return new WaitForSeconds(3);

        float wait = 0.5f;

        //用www读取一个assetBundle,里面是一个Unity基本球体和带一张大贴图的材质，是一个Prefab

        WWW aa = new WWW(@"file://SpherePrefab.unity3d");

        yield return aa;

        AssetBundle asset = aa.assetBundle;

        yield return new WaitForSeconds(wait);//每步都等待0.5s以便于分析结果

        Texture tt = asset.LoadAsset("BallTexture") as Texture;//加载贴图

        yield return new WaitForSeconds(wait);

        GameObject ba = asset.LoadAsset("SpherePrefab") as GameObject;//加载Prefab

        yield return new WaitForSeconds(wait);

        GameObject obj1 = Instantiate(ba) as GameObject;//生成实例

        yield return new WaitForSeconds(wait);

        Destroy(obj1);//销毁实例

        yield return new WaitForSeconds(wait);

        asset.Unload(false);//卸载Assetbundle

        yield return new WaitForSeconds(wait);

        Resources.UnloadUnusedAssets();//卸载无用资源

        yield return new WaitForSeconds(wait);

        ba = null;//将prefab引用置为空以后卸无用载资源

        Resources.UnloadUnusedAssets();

        yield return new WaitForSeconds(wait);

        tt = null;//将texture引用置为空以后卸载无用资源

        Resources.UnloadUnusedAssets();

    }

}
