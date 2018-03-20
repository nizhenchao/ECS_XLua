using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGLDrawCircle : MonoBehaviour
{
    //GL画线
    [SerializeField]
    private Material mat;
    // Use this for initialization
    void Start()
    {
        initMat();
    }

    private void initMat()
    {
        mat = new Material(Shader.Find("Tang/TUIDefault"));
    }

    //材质    
    void OnPostRender()
    {
        //绘制三角形        
       // DrawTriangle(100, 0, 100, 200, 200, 100, mat);
        DrawCircle(0.5f, 0.5f, 0, 0.2f,100);
    }

    void DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3, Material mat)
    {
        //mat.SetPass(0);
        //GL.LoadOrtho();
        ////绘制三角形
        //GL.Begin(GL.TRIANGLES);
        //GL.Vertex3(x1 / Screen.width, y1 / Screen.height, 0);
        //GL.Vertex3(x2 / Screen.width, y2 / Screen.height, 0);
        //GL.Vertex3(x3 / Screen.width, y3 / Screen.height, 0);
        //GL.End();

        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(1, 1, 0);
        GL.End();
        GL.PopMatrix();
    }


    void DrawCircle(float x, float y, float z, float r, float accuracy)
    {
        GL.PushMatrix();
        //绘制2D图像    
        mat.SetPass(0);
        GL.LoadOrtho();

        float stride = r * accuracy;
        float size = 1 / accuracy;
        float x1 = x, x2 = x, y1 = 0, y2 = 0;
        float x3 = x, x4 = x, y3 = 0, y4 = 0;

        double squareDe;
        squareDe = r * r - Math.Pow(x - x1, 2);
        squareDe = squareDe > 0 ? squareDe : 0;
        y1 = (float)(y + Math.Sqrt(squareDe));
        squareDe = r * r - Math.Pow(x - x1, 2);
        squareDe = squareDe > 0 ? squareDe : 0;
        y2 = (float)(y - Math.Sqrt(squareDe));
        for (int i = 0; i < size; i++)
        {
            x3 = x1 + stride;
            x4 = x2 - stride;
            squareDe = r * r - Math.Pow(x - x3, 2);
            squareDe = squareDe > 0 ? squareDe : 0;
            y3 = (float)(y + Math.Sqrt(squareDe));
            squareDe = r * r - Math.Pow(x - x4, 2);
            squareDe = squareDe > 0 ? squareDe : 0;
            y4 = (float)(y - Math.Sqrt(squareDe));

            //绘制线段
            GL.Begin(GL.LINES);
            GL.Color(Color.blue);
            GL.Vertex(new Vector3(x1 / Screen.width, y1 / Screen.height, z));
            GL.Vertex(new Vector3(x3 / Screen.width, y3 / Screen.height, z));
            GL.End();
            GL.Begin(GL.LINES);
            GL.Color(Color.blue);
            GL.Vertex(new Vector3(x2 / Screen.width, y1 / Screen.height, z));
            GL.Vertex(new Vector3(x4 / Screen.width, y3 / Screen.height, z));
            GL.End();
            GL.Begin(GL.LINES);
            GL.Color(Color.blue);
            GL.Vertex(new Vector3(x1 / Screen.width, y2 / Screen.height, z));
            GL.Vertex(new Vector3(x3 / Screen.width, y4 / Screen.height, z));
            GL.End();
            GL.Begin(GL.LINES);
            GL.Color(Color.blue);
            GL.Vertex(new Vector3(x2 / Screen.width, y2 / Screen.height, z));
            GL.Vertex(new Vector3(x4 / Screen.width, y4 / Screen.height, z));
            GL.End();

            x1 = x3;
            x2 = x4;
            y1 = y3;
            y2 = y4;
        }
        GL.PopMatrix();
    }
}
