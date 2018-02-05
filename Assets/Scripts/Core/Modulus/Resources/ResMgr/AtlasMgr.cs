using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class SpriteTask
{
    public long index = -1;
    public string name;
    public string bundleName;
    public Image img;


    public SpriteTask(long index, string name, string bundleName, Image img)
    {
        this.index = index;
        this.name = name;
        this.bundleName = bundleName;
        this.img = img;
        LoaderMgr.Instance.addTask(bundleName, onLoaderFinish);
    }

    private void onLoaderFinish(string result, bool isSucc, TBundle tb)
    {
        if (isSucc)
        {
            if (img != null)
            {
                Sprite sprite = tb.Ab.LoadAsset<Sprite>(name);
                img.sprite = sprite;                
            }
        }
    }
}


/// <summary>
/// 图集管理器
/// </summary>
public class AtlasMgr
{
    private static AtlasMgr instance;
    public static AtlasMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AtlasMgr();
            }
            return instance;
        }
    }

    private string cfgPath = "LuaScripts/Cfg/AtlasConfig.txt";
    private Dictionary<string, string> atlasCfg = null;
    private long index = 0;
    private Dictionary<long, SpriteTask> dictTask = null;

    public void initialize()
    {
        atlasCfg = new Dictionary<string, string>();
        dictTask = new Dictionary<long, SpriteTask>();
        initCfg();
    }

    private void initCfg()
    {
        string path = Path.Combine(Application.dataPath, cfgPath);
        if (!File.Exists(path))
        {
            Debug.LogError("图集配置未找到,请导出");
            return;
        }
        StreamReader sr = new StreamReader(path, Encoding.Default);
        String line;
        while ((line = sr.ReadLine()) != null)
        {
            //解析一行
            string[] lst = line.Split(':');
            atlasCfg.Add(lst[0], "atlas/" + lst[1]);
        }
        sr.Close();
        Debug.Log("<color=green>AtlasMgr initialize</color>");
    }

    private void setSpSprite(Image img, string name)
    {
        if (atlasCfg.ContainsKey(name))
        {
            string bundleName = atlasCfg[name];
            if (AssetMgr.isHave(bundleName))
            {
                TBundle tb = AssetMgr.getBundle(bundleName);
                img.sprite = tb.Ab.LoadAsset<Sprite>(name);
            }
            else
            {
                //需要加载ab
                index++;
                SpriteTask spTask = new SpriteTask(index, name, bundleName, img);
                dictTask.Add(index, spTask);
            }
        }
        else
        {
            Debug.LogError("请导出图集配置");
        }
    }

    #region 提供静态方法
    public static void setSprite(Image img, string name)
    {
        Instance.setSpSprite(img, name);
    }
    #endregion
}
