using System;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraWidget : MonoBehaviour
{
    Vector3 v3 = Vector3.zero;
    Vector3 rotOffset = new Vector3(20, 0, 0);
    Quaternion rot = Quaternion.identity;
    Vector3 shakeV3 = Vector3.zero;
    GameObject followPlayer = null;
    float distance = 10;
    float height = 6;

    public void setFollow(GameObject obj)
    {
        followPlayer = obj;
    }

    public void Update()
    {
        if (followPlayer == null)
        {
            return;
        }

        v3 = followPlayer.transform.position;
        v3 -= followPlayer.transform.forward * distance;
        v3 += followPlayer.transform.up * height;

        rot = followPlayer.transform.rotation;
        rot = rot * Quaternion.Euler(rotOffset);

        this.transform.position = Vector3.Lerp(Camera.main.transform.position, v3, 0.3f);
        this.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, rot, 0.3f);
    }

    private int getShakeRandom()
    {
        int val = UnityEngine.Random.Range(0, 2);
        return val == 1 ? -1 : 1;
    }



}

