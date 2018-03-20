using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCell : MonoBehaviour
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
    private RectTransform greenRect;
    private RectTransform redRect;
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

    private void Start()
    {
        resetValue();
    }
    
    private void resetValue()
    {
        greenPos = greenCell.transform.position;
        redPos = redCell.transform.position;
        //初始化圈大小
        greenRect = greenCell.GetComponent<RectTransform>();
        redRect = redCell.GetComponent<RectTransform>();
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
        greenRect.sizeDelta = new Vector2(greenRadius, greenRadius);
        redRect.sizeDelta = new Vector2(redRadius, redRadius);
        //100 0.005 0.0005
        float red = 0.49f + (redRadius - 100) * 0.0001f;
        float green = 0.49f + (greenRadius - 100) * 0.0001f;
        red = red >= 0.5f ? 0.496f : red;
        green = green >= 0.5f ? 0.496f : green;
        redRect.GetComponent<Image>().material.SetFloat("_CircleWidth", red);
        greenRect.GetComponent<Image>().material.SetFloat("_CircleWidth", green);
    }

}
