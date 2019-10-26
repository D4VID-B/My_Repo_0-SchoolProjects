using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelScript))]
public class LevelScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelScript instance = target as LevelScript; //cast target as a LevelScript ==> (LevelScript)target

        instance.experience = EditorGUILayout.IntField("Experience", instance.experience);

        EditorGUILayout.LabelField("Level", instance.level.ToString());
        
    }
}
