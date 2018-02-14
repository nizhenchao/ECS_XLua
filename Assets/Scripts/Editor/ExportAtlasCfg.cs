using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

/// <summary>
/// 导出图集配置工具
/// </summary>
public class ExportAtlasCfg
{
    //图集所在目录
    private const string atlasPath = "Assets/Res/Arts/Atlas";
    //导出路径
    private const string atlasCfgPath = "Assets/LuaScripts/Cfg";
    private const string writeSuffPath = "LuaScripts/Cfg/AtlasConfig.txt";
    private const string cfgFileName = "Assets/LuaScripts/Cfg/AtlasConfig.txt";

    [MenuItem("Assets/UI工具/导出图集配置", false, 3000)]
    public static void exportAtlasConfig()
    {
        checkExportPath();
        doExport(atlasPath);
    }

    private static void checkExportPath()
    {
        if (!Directory.Exists(atlasCfgPath))
        {
            Directory.CreateDirectory(atlasCfgPath);
        }
        if (File.Exists(cfgFileName))
        {
            File.Delete(cfgFileName);
        }
        //File.Create(cfgFileName);
    }

    private static void doExport(string path)
    {
        if (!Directory.Exists(path))
        {
            EditorUtility.DisplayDialog("不存在图集路径", "请检查图集路径", "Sure");
            return;
        }
        string[] dirs = Directory.GetDirectories(path);
        for (int i = 0; i < dirs.Length; i++)
        {
            //获取文件夹下面所有文件 .png?
            string[] fils = Directory.GetFiles(dirs[i], "*.png");
            for (int j = 0; j < fils.Length; j++)
            {
                AssetImporter imp = AssetImporter.GetAtPath(fils[i]);
                if (imp == null || !imp.assetBundleName.EndsWith(".assetbundle")) {
                    Debug.LogError("请先导出导出一次资源,再导出图集配置");
                }
                string bundleName = imp != null ? imp.assetBundleName : getFolderName(dirs[i]);
                string iconName = getFolderName(fils[j]);
                writeCfg(iconName, bundleName);
            }
        }
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        EditorUtility.DisplayDialog("导出图集配置完成", "生成目录 : " + cfgFileName, "确定");
    }

    private static void writeCfg(string iconName, string bundleName)
    {
        string path = Path.Combine(Application.dataPath, writeSuffPath);
        FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        //开始写入        
        StringBuilder builder = new StringBuilder();
        builder.Append(getIconName(iconName));
        builder.Append(":");
        builder.Append(getBundleName(bundleName));
        builder.Append("\n");
        sw.Write(builder.ToString());
        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();
    }

    static private string getIconName(string name)
    {
        string[] lst = name.Split('/');
        string realName = lst.Length <= 1 ? lst[0] : lst[lst.Length - 1];
        int index = realName.LastIndexOf('.');
        realName = realName.Substring(0, index);
        return realName;
    }

    static private string getBundleName(string name)
    {
        if (name.EndsWith(".assetbundle"))
        {
            name = name.Replace(".assetbundle", "");
            return name;
        }
        string[] lst = name.Split('\\');
        string realName = lst.Length >= 2 ? lst[lst.Length - 2]+"\\"+ lst[lst.Length - 1]: lst[0];
        return realName;
    }

    static private string getFolderName(string path)
    {
        string[] lst = path.Split('\\');
        return lst[lst.Length - 1];
    }


}
