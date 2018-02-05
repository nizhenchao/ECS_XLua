using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System.Diagnostics;

public class BuildAsset : MonoBehaviour
{
    //输出目录
    private const string outPath = "Assets/Res/AssetBundle";
    //打包目录
    private const string prefabsPath = "Assets/Res/Arts/Prefabs/";
    private const string atlasPath = "Assets/Res/Arts/Atlas/";
    private const string texturesPath = "Assets/Res/Arts/Textures/";
    private const string materialPath = "Assets/Res/Arts/Materials/";
    private const string shaderPath = "Assets/Res/Arts/Shader/";

    /// <summary>
    /// 打包所有被标记过AssetBundle name的资源
    /// </summary>
    [MenuItem("BuildAsset/BuildAll", true, 1002)]
    static void BuildABs()
    {
        if (Directory.Exists(outPath))
        {
            Directory.Delete(outPath,true);
        }
        if (!Directory.Exists(outPath))
        {
            Directory.CreateDirectory(outPath);
        }
        BuildPipeline.BuildAssetBundles(outPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        //游戏启动 加载ab依赖文件 加载bundle再从依赖文件中查找此bundle的依赖
        AssetDatabase.Refresh();
    }

    static void addPath(ref List<string> lst)
    {
        lst.Add(prefabsPath);
        lst.Add(atlasPath);
        lst.Add(texturesPath);
        lst.Add(materialPath);
        lst.Add(shaderPath);
    }

    /// <summary>
    /// 打包Res/Prefabs下面的所有资源
    /// </summary>
    [MenuItem("BuildAsset/BuildAB", false, 1001)]
    static void BuildFormResPrefabsPath()
    {
        List<string> lst = new List<string>();
        addPath(ref lst);
        for (int i = 0; i < lst.Count; i++)
        {
            if (!Directory.Exists(lst[i]))
            {
                Directory.CreateDirectory(lst[i]);
            }
        }
        Stopwatch watch = new Stopwatch();
        watch.Start();
        markRes(prefabsPath, ".prefab");
        markRes(atlasPath, ".png", true);
        markRes(texturesPath, ".png");
        markRes(materialPath, ".mat");
        markRes(shaderPath, ".shader");
        BuildABs();
        watch.Stop();

        EditorUtility.DisplayDialog("提示", "资源打包ab完毕 \n耗时 秒：" + (watch.ElapsedMilliseconds / 1000).ToString(), "确定");
    }

    //标记所有资源
    static private void markRes(string path, string suff, bool isAll = false)
    {
        if (Directory.Exists(path))
        {
            string name = null;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] files = dirInfo.GetFiles("*", SearchOption.AllDirectories);
            if (isAll)
            {
                name = getFolderName(path);
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.EndsWith(suff))
                {
                    AssetImporter imp = AssetImporter.GetAtPath(path + files[i].Name);
                    if (imp != null)
                    {
                        if (!isAll)
                        {
                            imp.assetBundleName = files[i].Name.Replace(suff, ".assetbundle");
                        }
                        else
                        {
                            imp.assetBundleName = name + ".assetbundle";
                        }
                    }
                }
            }
        }
    }



    static private string getFolderName(string path)
    {
        string[] lst = path.Split('/');
        return lst[lst.Length - 2];
    }



    static public void Write(string key, List<string> vals)
    {
        FileStream fs = new FileStream("E:\\depends.txt", FileMode.Create);
        StringBuilder value = new StringBuilder();
        value.Append(key + ':');
        for (int i = 0; i < vals.Count; i++)
        {
            value.Append(vals[i] + ',');
        }
        //获得字节数组
        byte[] data = System.Text.Encoding.Default.GetBytes(value.ToString());
        //开始写入
        fs.Write(data, 0, data.Length);
        //清空缓冲区、关闭流
        fs.Flush();
        fs.Close();
    }

}