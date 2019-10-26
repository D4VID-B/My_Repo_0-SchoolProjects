using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildSpheres))]

public class CreateSpheresEditor : Editor
{

    public override void OnInspectorGUI()
    {

        BuildSpheres instance = (BuildSpheres)target;

        #region Horizontal Buttons
        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Build Sphere"))
        {
            instance.buildSphere();
        }

        if(GUILayout.Button("Clear all Spheres"))
        {
            instance.clearSpheres();
        }
        EditorGUILayout.EndHorizontal();
        #endregion


        base.OnInspectorGUI();
    }
}
