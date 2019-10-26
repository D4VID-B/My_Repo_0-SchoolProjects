using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SomeScript))]

public class SomeScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Here is some random info", MessageType.Info);
        EditorGUILayout.HelpBox("Error: Everything is on fire.", MessageType.Error);
        EditorGUILayout.HelpBox("Warning: Everything is about to be on fire.", MessageType.Warning);
        EditorGUILayout.HelpBox("Stuff!", MessageType.None);
        base.OnInspectorGUI();

    }

}

