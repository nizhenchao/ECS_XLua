using System;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardWidget : MonoBehaviour
{
    private Transform cacheTrans = null;
    public Transform CacheTrans
    {
        get
        {
            if (cacheTrans == null)
            {
                cacheTrans = this.transform;
            }
            return cacheTrans;
        }
    }
    private Transform mainCamera = null;
    public Transform MainCamera
    {
        get
        {
            if (mainCamera == null)
            {
                GameObject go = GameObject.FindGameObjectWithTag("PlayerCamera");
                if (go != null)
                {
                    mainCamera = go.transform;
                }
            }
            return mainCamera;
        }
    }

    private TextMesh namePart = null;

    public void Update()
    {
        if (MainCamera != null)
        {
            CacheTrans.rotation = Quaternion.Lerp(CacheTrans.rotation, MainCamera.rotation, 0.8f);
        }
    }

    public void setName(string name,float height) {
        if (namePart == null) {
            //创建
            GameObject bg = new GameObject("namePartBg");
            bg.transform.SetParent(CacheTrans);
            bg.transform.localPosition = new Vector3(0, height, 0);
            SpriteRenderer renderer = bg.AddComponent<SpriteRenderer>();
            AtlasMgr.setSprite(renderer, "yeqianButtonChose2");
           // renderer.drawMode = SpriteDrawMode.Sliced;
            //renderer.size = new Vector2(1.8f, 0.4f);
            GameObject go = new GameObject("namePart");
            go.transform.SetParent(bg.transform);
            go.transform.localPosition = new Vector3(0, 0, -0.05f);
            namePart = go.AddComponent<TextMesh>();
            namePart.characterSize = 0.1f;
            namePart.fontSize = 28;
            namePart.anchor = TextAnchor.MiddleCenter;
            namePart.alignment = TextAlignment.Center;
        }
        namePart.text = name;
    }

}

