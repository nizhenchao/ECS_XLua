using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using OfficeOpenXml;
using System.IO;
using System;
using System.Text;

/// <summary>
/// 根据美术配置的动画片段  裁剪动画 并创建animator
/// 根据策划配置的动画帧事件  创建动画clip帧事件
/// 文件夹命名规范 美术:预设名与文件夹名相同 ,导入Unity都放在FBX目录下
/// </summary>
public class AnimTool
{
    [MenuItem("Assets/AnimTools/导出动画")]
    public static void exportAnim() {
        UnityEngine.Object obj = Selection.activeObject;
        if (obj == null||!obj.name.EndsWith("@mat")) {
            Debug.LogError("请选中正确的模型");
            return;
        }
        Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
        
    }

    /// <summary>
    /// 以下获取配置方法
    /// </summary>
    private const int dataRowIndex = 3;
    //读取excel by path
    //返回 dict <  id,li  >
    public static Dictionary<int, List<string>> getExcelByPath(string path)
    {
        Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
        using (ExcelPackage package = new ExcelPackage(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
        {            
            ExcelWorksheet sheet = package.Workbook.Worksheets[1];
            int maxRow = sheet.Dimension.End.Row;
            if (maxRow >= dataRowIndex)
            {
                for (int i = 1; i <= maxRow; i++)
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
        return dict;
    }

    //读取一行
    public static void readRow(ExcelWorksheet sheet, int index, ref List<string> lst)
    {
        int maxCol = sheet.Dimension.End.Column;
        for (int i = 1; i <= maxCol; i++)
        {
            //拿当前列 第4行 字段为空 跳过
            object proVal = sheet.GetValue(4, i);
            if (proVal == null || string.IsNullOrEmpty(proVal.ToString())) continue;

            object val = sheet.GetValue(index, i);
            lst.Add(val != null ? val.ToString() : "");
        }
    }

}
