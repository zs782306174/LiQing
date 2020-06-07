#if ILRuntime
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using ETModel;

public static class ILRuntimeCLRBinding
{
    //[MenuItem("Tools/ILRuntime/Generate CLR Binding Code")]
    static void GenerateCLRBinding()
    {
        List<Type> types = new List<Type>();
        types.Add(typeof(int));
        types.Add(typeof(float));
        types.Add(typeof(long));
        types.Add(typeof(object));
        types.Add(typeof(string));
        types.Add(typeof(Array));
        types.Add(typeof(Vector2));
        types.Add(typeof(Vector3));
        types.Add(typeof(Quaternion));
        types.Add(typeof(GameObject));
        types.Add(typeof(UnityEngine.Object));
        types.Add(typeof(Transform));
        types.Add(typeof(RectTransform));
        types.Add(typeof(Time));
        types.Add(typeof(Debug));
        //所有DLL内的类型的真实C#类型都是ILTypeInstance
        types.Add(typeof(List<ILRuntime.Runtime.Intepreter.ILTypeInstance>));

        ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(types, "Assets/Model/ILBinding");
		AssetDatabase.Refresh();
    }

    [MenuItem("Tools/ILRuntime/Generate CLR Binding Code by Analysis")]
    static void GenerateCLRBindingByAnalysis()
    {
	    GenerateCLRBinding();
	    
        //用新的分析热更dll调用引用来生成绑定代码
        ILRuntime.Runtime.Enviorment.AppDomain domain = new ILRuntime.Runtime.Enviorment.AppDomain();
        using (FileStream fs = new FileStream("Assets/Res/Code/Hotfix.dll.bytes", FileMode.Open, FileAccess.Read))
        {
	        domain.LoadAssembly(fs);
	        //Crossbind Adapter is needed to generate the correct binding code
	        ILHelper.InitILRuntime(domain);
	        ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(domain, "Assets/Model/ILBinding");
	        AssetDatabase.Refresh();
        }
    }


}
#endif

public class GetAnimation
{
    [MenuItem("AnimationTool/GetAnimation", true)]
    static bool NotSelection()
    {
        return Selection.activeObject;     //判断是否选择的物体 没选择的话无法执行工具
    }

    [MenuItem("AnimationTool/GetAnimation")]
    static void Get()
    {
        string targetPath = Application.dataPath + "/AnimationClip";          //目录AnimationClip
        if (!Directory.Exists(targetPath))
        {
            Directory.CreateDirectory(targetPath);     //如果目录不存在就创建一个
        }
        UnityEngine.Object[] objects = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Unfiltered);     //获取所有选中的物体
        foreach (UnityEngine.Object o in objects)     //遍历选择的物体
        {
            AnimationClip clip = new AnimationClip();      //new一个AnimationClip存放生成的AnimationClip
            string fbxPath = AssetDatabase.GetAssetPath(o);       //FBX的地址
            string name = o.name;     //FBX的名字
            AnimationClip fbxClip = AssetDatabase.LoadAssetAtPath<AnimationClip>(fbxPath);     //获取FBX上的animationClip
            if (fbxClip == null)
            {
                Debug.Log("当前选择的文件不是带有AnimationClip的FBX文件");
            }
            else
            {
                EditorUtility.CopySerialized(fbxClip, clip);    //复制
                AssetDatabase.CreateAsset(clip, "Assets/AnimationClip/" + name + ".anim");    //生成文件
            }
        }
    }
}