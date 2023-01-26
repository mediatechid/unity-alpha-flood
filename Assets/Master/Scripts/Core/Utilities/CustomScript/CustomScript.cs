using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
 
using UnityEditor;
 
using System.IO;
using MenuCommand = UnityEditor.MenuCommand;

public static class CustomScript
{
    private const string PATH_TO_MYSCRIPT_TEMPLATE = @"Assets\Master\Scripts\Core\Utilities\CustomScript\NewUpdatedBehaviour.cs";
 
    [MenuItem("Assets/Custom C# Script/Updated C# Behaviour Script")]
    public static void CreateCustomScript(MenuCommand menuCommand)
    {
        CreateScriptAsset(PATH_TO_MYSCRIPT_TEMPLATE, "NewUpdatedBehaviour.cs");
        
        // if (Selection.activeObject == null);
        // var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        // if (File.Exists(path))
        //     path = Path.GetDirectoryName(path);
        // if (string.IsNullOrEmpty(path)) path = "Assets/";
        //
        //
        // File.Copy(PATH_TO_MYSCRIPT_TEMPLATE, Path.Combine(path, "NewUpdateBehaviour.cs"));
        // AssetDatabase.Refresh();
 
    }
    
    static void CreateScriptAsset(string templatePath, string destName) {
#if UNITY_2019_1_OR_NEWER
        UnityEditor.ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, destName);
#else
	typeof(UnityEditor.ProjectWindowUtil)
		.GetMethod("CreateScriptAsset", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
		.Invoke(null, new object[] { templatePath, destName });
#endif
    }
}