using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EntityListener))]
public class EntityListenerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Takes an Entity object and allows the user to run a few test functions, to speed up debugging", MessageType.Info);

        EntityListener instance = (EntityListener)target;

        instance.target = (Entity)EditorGUILayout.ObjectField("Object To Watch", instance.target, typeof(Entity), true);


        GUILayout.Label("Make sure the object is an Entity!");
        if(GUILayout.Button("Ping Connected Object"))
        {
            instance.testFunction();
        }

        //base.OnInspectorGUI();
    }
}
