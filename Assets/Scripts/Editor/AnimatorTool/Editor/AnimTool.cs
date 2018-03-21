using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using OfficeOpenXml;
using System.IO;
using System;
using System.Text;

//切片
public struct animClip
{
    public string modelName;
    public string clipName;
    public int startIndex;
    public int endIndex;
    public bool isLoop;
}

//帧事件
public class animEventTotal
{
    public List<animEvent> eventLst = new List<animEvent>();
}
public struct animEvent
{
    public string clipName;
    public float frame;
    public string eventName;
    public string args;
}

//条件
public struct animCond
{
    public string clipName;
    public bool isDefault;
    public string fromState;
    public string fromCond;
    public string toState;
    public string toCond;
}


/// <summary>
/// 根据美术配置的动画片段  裁剪动画 并创建animator
/// 根据策划配置的动画帧事件  创建动画clip帧事件
/// 文件夹命名规范 美术:预设名与文件夹名相同 ,导入Unity都放在FBX目录下
/// </summary>
public class AnimTool
{
    private const string fbxPath = "Assets/Res/Arts/FBX";//FBX源文件路径（包含动画 模型）
    private const string clipSuff = "AnimClip.xlsx";//动画切片excel后缀
    private const string condSuff = "AnimCond.xlsx";//动画状态机条件excel后缀
    private const string eventSuff = "AnimEvent.xlsx";//帧事件excel后缀

    private const string clipPath = "Assets/Res/Arts/AnimClips";//导出动画切片
    private const string acPath = "Assets/Res/Arts/Animators";//导出animactorControl路径
    private const string prefabPath = "Assets/Res/Arts/Prefabs/ModelPrefabs/";//存放预设路径

    private const string animSuff = "Amt";
    private const string defaultAnim = "Stand";

    [MenuItem("Assets/AnimTools/导出动画")]
    public static void exportAnim()
    {
        string objName = "";//FBX名称
        string objPath = "";//FBX路径
        UnityEngine.Object obj = Selection.activeObject;
        if (obj == null || !obj.name.EndsWith(animSuff))
        {
            Debug.LogError("请选中正确的模型");
            return;
        }
        objName = obj.name.Replace(animSuff, "");
        objPath = Path.Combine(fbxPath, objName + "/" + obj.name);
        string clipPath = Path.Combine(fbxPath, objName + "/" + objName + clipSuff);
        string condPath = Path.Combine(fbxPath, objName + "/" + objName + condSuff);
        string eventPath = Path.Combine(fbxPath, objName + "/" + objName + eventSuff);
        //切片信息
        List<animClip> clips = new List<animClip>();
        getClips(clipPath, ref clips);
        createCilp(objPath, eventPath, clips);

        //ac信息
        Dictionary<string, animCond> conds = new Dictionary<string, animCond>();
        getCond(condPath, ref conds);
        createAC(objPath, objName, conds);

        //保存prefabs
        createPrefabs(objPath, objName);
    }

    #region 保存为prefab
    private static void createPrefabs(string objPath, string objName)
    {
        string resPath = objPath.Replace("Amt", "");
        int index = objPath.LastIndexOf("/");
        string root = objPath.Remove(index);
        string acPath = Path.Combine(root, "bin/ac/" + objName + ".controller");
        if (!Directory.Exists(prefabPath)) Directory.CreateDirectory(prefabPath);

        GameObject obj = AssetDatabase.LoadAssetAtPath(resPath + ".prefab", typeof(UnityEngine.GameObject)) as GameObject;
        if (obj == null)
        {
            Debug.LogError("模型预设资源不存在: " + resPath);
            return;
        }
        AnimatorController ac = AssetDatabase.LoadAssetAtPath<AnimatorController>(acPath);
        obj.GetComponent<Animator>().runtimeAnimatorController = ac;
        GameObject go = new GameObject(objName);
        EditorUtility.CopySerialized(obj, go);
        string name = string.Format("{0}.prefab", objName);
        string savePath = Path.Combine(prefabPath, name);
        savePath.Replace("\\", "/");
        UnityEngine.Object pref = PrefabUtility.CreateEmptyPrefab(savePath);
        PrefabUtility.ReplacePrefab(obj, pref);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    #endregion

    #region 创建动画切片
    private static void createCilp(string objPath, string eventPath, List<animClip> clips)
    {
        string path = objPath + ".FBX";
        var modelImporter = AssetImporter.GetAtPath(path) as ModelImporter;
        if (modelImporter == null) return;

        int index = objPath.LastIndexOf("/");
        string savePath = objPath.Remove(index);
        savePath = Path.Combine(savePath, "bin/clip");
        if (Directory.Exists(savePath)) Directory.Delete(savePath, true);
        if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

        //帧事件信息
        Dictionary<string, animEventTotal> events = new Dictionary<string, animEventTotal>();
        getEvent(eventPath, ref events);

        modelImporter.animationType = ModelImporterAnimationType.Generic;
        modelImporter.importAnimation = true;
        modelImporter.generateAnimations = ModelImporterGenerateAnimations.GenerateAnimations;
        ModelImporterClipAnimation[] animations = new ModelImporterClipAnimation[clips.Count];
        for (int i = 0; i < clips.Count; i++)
        {
            ModelImporterClipAnimation tempClip = new ModelImporterClipAnimation();
            tempClip.name = clips[i].clipName;
            tempClip.firstFrame = clips[i].startIndex;
            tempClip.lastFrame = clips[i].endIndex;
            tempClip.loopTime = clips[i].isLoop;
            tempClip.wrapMode = clips[i].isLoop ? WrapMode.Loop : WrapMode.Default;
            if (events.ContainsKey(tempClip.name))
            {
                animEventTotal total = events[tempClip.name];
                AnimationEvent[] clipEvents = new AnimationEvent[total.eventLst.Count];
                for (int k = 0; k < total.eventLst.Count; k++)
                {
                    AnimationEvent ae = new AnimationEvent();
                    ae.functionName = total.eventLst[k].eventName;
                    ae.stringParameter = total.eventLst[k].args;
                    ae.time = total.eventLst[k].frame;
                    clipEvents[k] = ae;
                }
                tempClip.events = clipEvents;
            }
            animations[i] = tempClip;
        }
        modelImporter.clipAnimations = animations;

        UnityEngine.Object[] objs = AssetDatabase.LoadAllAssetsAtPath(path);
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i] is AnimationClip && !objs[i].name.StartsWith("_"))
            {
                AnimationClip old = objs[i] as AnimationClip;
                AnimationClip newClip = new AnimationClip();
                EditorUtility.CopySerialized(old, newClip);
                AssetDatabase.CreateAsset(newClip, Path.Combine(savePath, newClip.name + ".anim"));
            }
        }
        //AssetDatabase.ImportAsset(modelImporter.assetPath);
        AssetDatabase.Refresh();
    }


    private static void getClips(string clipPath, ref List<animClip> clips)
    {
        Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
        getExcelByPath(clipPath, ref dict);
        foreach (var item in dict)
        {
            List<string> vals = item.Value;
            animClip clip = new animClip();
            clip.modelName = vals[0];
            clip.clipName = vals[1];
            clip.startIndex = int.Parse(vals[2]);
            clip.endIndex = int.Parse(vals[3]);
            clip.isLoop = vals[4] == "1";
            clips.Add(clip);
        }
    }
    #endregion

    #region 添加动画帧事件
    private static void getEvent(string eventPath, ref Dictionary<string, animEventTotal> events)
    {
        Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
        getExcelByPath(eventPath, ref dict);
        foreach (var item in dict)
        {
            List<string> vals = item.Value;
            animEventTotal allEvent = new animEventTotal();
            addEvent(vals, 1, ref allEvent);
            events.Add(vals[0], allEvent);
        }
    }
    //递归查找excel里面的帧事件
    private static void addEvent(List<string> vals, int index, ref animEventTotal allEvent)
    {
        if (vals.Count <= index) return;
        if (vals[index].StartsWith("play"))
        {
            animEvent e = new animEvent();
            e.clipName = vals[0];
            e.eventName = vals[index];
            e.frame = float.Parse(vals[index + 1]);
            e.args = vals[index + 2];
            allEvent.eventLst.Add(e);
            addEvent(vals, index + 3, ref allEvent);
        }
    }
    #endregion

    #region 创建animatorContorller
    private static void createAC(string objPath, string objName, Dictionary<string, animCond> conds)
    {
        int index = objPath.LastIndexOf("/");
        string savePath = objPath.Remove(index);
        string clipPath = Path.Combine(savePath, "bin/clip");
        savePath = Path.Combine(savePath, "bin/ac");
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        AnimatorController ac = new AnimatorController();
        AnimatorControllerLayer layer = new AnimatorControllerLayer();
        layer.name = "Base";
        //添加clip        
        AnimatorStateMachine stateMachine = new AnimatorStateMachine();
        string[] files = Directory.GetFiles(clipPath, "*anim");
        List<AnimationClip> clips = new List<AnimationClip>();
        for (int i = 0; i < files.Length; i++)
        {
            AnimationClip cp = AssetDatabase.LoadAssetAtPath<AnimationClip>(files[i]);
            if (cp != null)
            {
                clips.Add(cp);
            }
        }
        int startY = 0;
        bool isLeft = false;
        int startX = 0;
        for (int i = 0; i < clips.Count; i++)
        {
            AnimatorState animState = new AnimatorState();
            animState.motion = clips[i] as AnimationClip;
            string name = clips[i].name;
            animState.name = name;
            bool isStand = name == defaultAnim;
            startY = isStand ? startY : startY + 1;
            if (!isStand)
            {
                startX = 430;// isLeft ? 430 + 100 : 430 - 100;
                isLeft = !isLeft;
            }
            stateMachine.AddState(animState, isStand ? new Vector2(430, 0) : new Vector2(startX, startY * 100));
            if (isStand)
                stateMachine.defaultState = animState;
        }
        //连线
        ChildAnimatorState[] states = stateMachine.states;
        for (int i = 0; i < states.Length; i++)
        {
            ChildAnimatorState currState = states[i];
            string name = currState.state.name;
            if (conds.ContainsKey(name))
            {
                animCond cond = conds[name];
                string fromStateName = cond.fromState;
                if (fromStateName == "Any State")
                {
                    AnimatorStateTransition trans = stateMachine.AddAnyStateTransition(currState.state);
                    if (!isExitParam(ac, cond.fromCond))
                        ac.AddParameter(cond.fromCond, AnimatorControllerParameterType.Trigger);
                    trans.AddCondition(AnimatorConditionMode.Equals, 0, cond.fromCond);
                }
                string toStateName = cond.toState;
                ChildAnimatorState toState = getState(states, toStateName);
                if (toState.state != null && name != defaultAnim)
                {
                    AnimatorStateTransition trans = currState.state.AddTransition(toState.state);
                    if (cond.toCond == "None")
                    {
                        trans.hasExitTime = true;
                    }
                    else
                    {
                        if (!isExitParam(ac, cond.toCond))
                            ac.AddParameter(cond.toCond, AnimatorControllerParameterType.Trigger);
                        trans.AddCondition(AnimatorConditionMode.Equals, 0, cond.toCond);
                    }
                }
            }
        }

        layer.stateMachine = stateMachine;
        ac.AddLayer(layer);
        ac.name = objName;
        AssetDatabase.CreateAsset(ac, Path.Combine(savePath, objName + ".controller"));
    }

    private static bool isExitParam(AnimatorController ac, string name)
    {
        AnimatorControllerParameter[] lst = ac.parameters;
        for (int i = 0; i < lst.Length; i++)
        {
            if (lst[i].name == name)
                return true;
        }
        return false;
    }

    private static ChildAnimatorState getState(ChildAnimatorState[] states, string name)
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].state.name == name)
            {
                return states[i];
            }
        }
        return new ChildAnimatorState();
    }

    private static void getCond(string condPath, ref Dictionary<string, animCond> conds)
    {
        Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
        getExcelByPath(condPath, ref dict);
        foreach (var item in dict)
        {
            List<string> vals = item.Value;
            animCond cond = new animCond();
            cond.clipName = vals[0];
            cond.isDefault = int.Parse(vals[1]) == 1;
            cond.fromState = vals[2] == "0" ? "Any State" : vals[2];
            cond.fromCond = vals[3];
            cond.toState = vals[4] == "0" ? defaultAnim : vals[4];
            cond.toCond = vals[5] == "0" ? "None" : vals[5];
            conds.Add(cond.clipName, cond);
        }
    }
    #endregion


    #region   以下获取配置方法
    /// <summary>
    /// 以下获取配置方法
    /// </summary>
    private const int dataRowIndex = 3;//所有excel配置从第三行读取(前两行备注)
    //读取excel by path
    //返回 dict <  id,li  >
    public static void getExcelByPath(string path, ref Dictionary<int, List<string>> dict)
    {
        using (ExcelPackage package = new ExcelPackage(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
        {
            ExcelWorksheet sheet = package.Workbook.Worksheets[1];
            int maxRow = sheet.Dimension.End.Row;
            if (maxRow >= dataRowIndex)
            {
                for (int i = dataRowIndex; i <= maxRow; i++)
                {
                    //如果当前行 第一个元素为空 continue                    
                    object val = sheet.GetValue(i, 1);
                    if (i >= dataRowIndex && (val == null || string.IsNullOrEmpty(val.ToString()))) continue;
                    List<string> lst = new List<string>();
                    readRow(sheet, i, ref lst);
                    dict.Add(i, lst);
                }
            }
            else
            {
                Debug.LogError("配置表格式有问题 ");
            }
        }
    }

    //读取一行
    public static void readRow(ExcelWorksheet sheet, int index, ref List<string> lst)
    {
        int maxCol = sheet.Dimension.End.Column;
        for (int i = 1; i <= maxCol; i++)
        {
            object val = sheet.GetValue(index, i);
            lst.Add(val != null ? val.ToString() : "null");
        }
    }
    #endregion
}
