using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SampleWindow : EditorWindow
{
    string aString;
    bool aBool = true;
    float aFloat = 1.1f;

    bool groupEnabled;

    [MenuItem("Window/Sample Window")]
 static void showWindow()
    {
        EditorWindow.GetWindow(typeof(SampleWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("Sample Winow", EditorStyles.boldLabel);
        aString = EditorGUILayout.TextField("A String", aString);


        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
       
            aBool = EditorGUILayout.Toggle("A Boolean", aBool);

            aFloat = EditorGUILayout.Slider("A Slider", aFloat, -100f, 100f);
        
        EditorGUILayout.EndToggleGroup();
        
    }

}
