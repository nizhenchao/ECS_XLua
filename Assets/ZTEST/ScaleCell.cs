using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleCell : MonoBehaviour
{
    [Header("勾选开始缩圈")]
    public bool isStart = false;
    [Header("重新开始")]
    public bool reset = false;
    [Header("缩圈时间")]
    public float timer = 3;
    [Header("绿红obj")]
    public GameObject greenCell = null;
    public GameObject redCell = null;

    [Header("地图大小")]
    public float mapLen = 600;

    [Header("绿圈大小")]
    public float greenRadius = 100;
    [Header("红圈大小")]
    public float redRadius = 400;


    private Vector3 greenPos = Vector3.zero;
    private Vector3 redPos = Vector3.zero;
    private Transform greenRect;
    private Transform redRect;
    [Header("移动速度,请勿修改")]
    [SerializeField]
    private float speed = 0;
    [Header("缩小速度,请勿修改")]
    [SerializeField]
    private float scaleSpeed = 0;
    [Header("计时器,请勿修改")]
    [SerializeField]
    private float clock = 0;
    //红圈移动方向
    private Vector3 moveDir = Vector3.zero;

    private Vector3 greenScale = Vector3.zero;
    private Vector3 redScale = Vector3.zero;
    
    private float orgScaleMul = 200;

    private void Start()
    {
        resetValue();
    }

    private void resetValue()
    {
        //使用缩放控制 特效大小
        //地图初始大小 特效初始大小
        float greenscale = greenRadius / mapLen;
        greenScale = new Vector3(greenscale, greenscale, greenscale);        
        float redscale = redRadius / mapLen;
        redScale = new Vector3(redscale, redscale, redscale);
        greenPos = greenCell.transform.position;
        redPos = redCell.transform.position;
        //初始化圈大小
        greenRect = greenCell.GetComponent<Transform>();
        redRect = redCell.GetComponent<Transform>();
        drawCircle();
        Vector3 distance = greenPos - redPos;
        float dis = distance.magnitude;
        speed = (dis / timer);
        scaleSpeed = (redRadius - greenRadius) / timer;
        moveDir = distance.normalized;
    }

    public void Update()
    {
        if (reset)
        {
            resetValue();
            drawCircle();
            clock = 0;
            reset = false;
        }
        if (!isStart) return;
        redRadius -= scaleSpeed * Time.deltaTime;
        redScale = new Vector3(redRadius / mapLen, redRadius / mapLen, redRadius / mapLen);
        redRect.position += moveDir * speed * Time.deltaTime;
        clock += Time.deltaTime;
        if (redRadius <= greenRadius)
        {
            redRadius = greenRadius;
            isStart = false;
        }
        drawCircle();
    }

    private void drawCircle()
    {
        greenRect.localScale = greenScale* orgScaleMul;
        redRect.localScale = redScale* orgScaleMul;        
    }


    //画线
    public void OnDrawGizmos()
    {
        greenPos = greenCell.transform.position;
        redPos = redCell.transform.position;
        int count = 360;
        //绿圈线
        Vector3 center = greenPos;
        Gizmos.color = Color.yellow;        
        float r = greenRadius;
        for (int i = 0; i < count; i++)
        {
            float x1 = center.x + r * Mathf.Cos(i * Mathf.PI / 180);
            float z1 = center.z + r * Mathf.Sin(i * Mathf.PI / 180);
            Vector3 pos1 = new Vector3(x1, 100, z1);

            float x2 = center.x + r * Mathf.Cos((i + 1) * Mathf.PI / 180);
            float z2 = center.z + r * Mathf.Sin((i + 1) * Mathf.PI / 180);
            Vector3 pos2 = new Vector3(x2, 110, z2);
            Gizmos.DrawLine(pos1, pos2);        
        }
        //红圈线
         center = redPos;
        Gizmos.color = Color.red;
         r = redRadius;
        for (int i = 0; i < count; i++)
        {
            float x1 = center.x + r * Mathf.Cos(i * Mathf.PI / 180);
            float z1 = center.z + r * Mathf.Sin(i * Mathf.PI / 180);
            Vector3 pos1 = new Vector3(x1, 100, z1);

            float x2 = center.x + r * Mathf.Cos((i + 1) * Mathf.PI / 180);
            float z2 = center.z + r * Mathf.Sin((i + 1) * Mathf.PI / 180);
            Vector3 pos2 = new Vector3(x2, 110, z2);
            Gizmos.DrawLine(pos1, pos2);
        }
    }

}
