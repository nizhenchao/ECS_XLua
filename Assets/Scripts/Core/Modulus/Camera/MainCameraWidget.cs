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
    //相机震动
    float shakeTime = -1;
    float Attenuation = 1;
    float HorShakeVal = 1;
    float VerShakeVal = 1;

    public void setFollow(GameObject obj)
    {
        followPlayer = obj;
    }

    private Transform main = null;
    private Transform Main
    {
        get
        {
            if (main == null)
            {
                main = this.transform.GetChild(0);
            }
            return main;
        }
    }

    public void Update()
    {
        if (followPlayer == null)
        {
            return;
        }
        if (shakeTime > 0)
        {
            float del = Time.deltaTime;
            float h = UnityEngine.Random.Range(0, Attenuation);
            float v = UnityEngine.Random.Range(0, Attenuation);
            HorShakeVal -= h;
            HorShakeVal = HorShakeVal <= 0 ? 0 : HorShakeVal;
            VerShakeVal -= v;
            VerShakeVal = VerShakeVal <= 0 ? 0 : VerShakeVal;
            shakeV3.x = HorShakeVal * getShakeRandom();
            shakeV3.y = VerShakeVal * getShakeRandom();
            Main.transform.localPosition = shakeV3;
            shakeTime -= del;
            if (shakeTime <= 0) resetShake();
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

    public void doShake(float time, float Attenuation = 0.1f, float HorShakeVal = 1, float VerShakeVal = 1)
    {
        this.shakeTime = time;
        this.Attenuation = Attenuation;
        this.HorShakeVal = HorShakeVal;
        this.VerShakeVal = VerShakeVal;
    }

    private  void resetShake()
    {
        this.shakeTime = 0;
        this.Attenuation = 0;
        this.HorShakeVal = 0;
        this.VerShakeVal = 0;
    }


}

