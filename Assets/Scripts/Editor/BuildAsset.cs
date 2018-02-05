using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System.Diagnostics;

/// <summary>
/// 打包AssetBundle工具
/// </summary>
public class BuildAsset
{
    //输出目录
    private const string outPath = "Assets/Res/AssetBundle";
    //打包目录
    private const string prefabsPath = "Assets/Res/Arts/Prefabs";
    private const string texturesPath = "Assets/Res/Arts/Textures";
    private const string materialPath = "Assets/Res/Arts/Materials";
    private const string shaderPath = "Assets/Res/Arts/Shader";
    //打包图集 每个文件夹下面打包成一个ab
    private const string atlasPath = "Assets/Res/Arts/Atlas";
    /// <summary>
    /// 打包所有被标记过AssetBundle name的资源
    /// </summary>
    [MenuItem("BuildAsset/BuildAll", true, 1002)]
    static void BuildABs()
    {
        if (Directory.Exists(outPath))
        {
            Directory.Delete(outPath, true);
        }
        if (!Directory.Exists(outPath))
        {
            Directory.CreateDirectory(outPath);
        }
        EditorUtility.DisplayProgressBar("导出assetbundle中", "正在导出", 0.5f);
        BuildPipeline.BuildAssetBundles(outPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        EditorUtility.DisplayProgressBar("导出assetbundle中", "正在导出", 0.8f);
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
    [MenuItem("BuildAsset/BuildAssetBundle", false, 1001)]
    static void BuildFormResPrefabsPath()
    {
        EditorUtility.DisplayProgressBar("导出assetbundle中", "正在导出", 0.2f);
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
        markRes(texturesPath, ".png");
        markRes(materialPath, ".mat");
        markRes(shaderPath, ".shader");
        markResDirectory(atlasPath, ".png", true);
        BuildABs();
        watch.Stop();
        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("提示", "资源打包ab完毕 \n耗时 秒：" + (watch.ElapsedMilliseconds / 1000).ToString(), "确定");
    }

    //标记文件下面的所有文件夹资源后缀
    //主要用于标记图集资源 图集资源位于Atlas文件夹下面
    //有划分多个文件夹 每个文件夹打成一个ab
    static private void markResDirectory(string path, string suff, bool isAll = false)
    {
        if (Directory.Exists(path))
        {
            string[] dirs = Directory.GetDirectories(path);
            for (int i = 0; i < dirs.Length; i++)
            {
                markRes(dirs[i], suff, isAll);
            }
        }
    }


    /// <summary>
    ///   标记所有资源
    /// </summary>
    /// <param name="path"></param>文件夹
    /// <param name="suff"></param>文件后缀
    /// <param name="isAll"></param>是否把文件夹下面所有资源打包到一个ab
    static private void markRes(string path, string suff, bool isAll = false)
    {
        if (Directory.Exists(path))
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] files = dirInfo.GetFiles("*", SearchOption.AllDirectories);
            string name = isAll ? getFolderName(path) : "";

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.EndsWith(suff))
                {
                    AssetImporter imp = AssetImporter.GetAtPath(Path.Combine(path, files[i].Name));
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

        return lst[lst.Length - 1];
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