using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DoSomethingFromMenu
{
    [MenuItem("Tools/Do Something")]
    public static void doSomething()
    {
        Debug.Log("Something done");
    }

    [MenuItem("Tools/Level01/Do something Else")]
    static void doSomethingElse()
    {
        Debug.Log("SOmething else");
    }

    [MenuItem("Tools/Destroy Selected Objects")]
    public static void destroySelectedObjects()
    {
        Transform[] selected = Selection.transforms;

        foreach(Transform t in selected)
        {
            Object.DestroyImmediate(t.gameObject);
        }
    }
}
