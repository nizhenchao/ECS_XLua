using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct circleInfo
{
    public Vector3 orgPos;
    public float radius;

    public circleInfo(Vector3 pos, float r) {
        orgPos = pos;
        radius = r * 2;
    }

}

public class DrawCircleZZ : MonoBehaviour
{
    public GameObject temp;
    public List<circleInfo> lst = new List<circleInfo>();


    private void Start()
    {
        circleInfo c1 = new circleInfo(new Vector3(99.3f,13.2f,154.2f),2);
        lst.Add(c1);
        circleInfo c2 = new circleInfo(new Vector3(98.905846f, 13.2f, 151.49072f), 6);
        lst.Add(c2);
        circleInfo c3 = new circleInfo(new Vector3(100.96731f, 13.2f, 152.8635f), 11);
        lst.Add(c3);
        circleInfo c4 = new circleInfo(new Vector3(95.164474f, 13.2f, 153.73521f), 17);
        lst.Add(c4);

        for (int i = 0; i < lst.Count; i++)
        {
            GameObject go = GameObject.Instantiate(temp);
            go.transform.position = lst[i].orgPos;
            go.transform.localScale = new Vector3(lst[i].radius, lst[i].radius, 1);
        }
    }


}
