using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Collector))]
public class CollectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("An incapsulation of the list class, to speed up the collection and processing of various user-defined objects.", MessageType.Info);

        Collector instance = (Collector)target;


        EditorGUILayout.HelpBox("Select the main search parameter:", MessageType.None);
        instance.ObjectType = (Collector.ObjectClass)EditorGUILayout.EnumPopup("Object Type", instance.ObjectType);
        //Display any relevant information, depending on type choice. E.g: A string input box

        if(instance.ObjectType == Collector.ObjectClass.GameObject)
        {
            if (instance.SearchBy == Collector.ObjectSearchType.Layer)
            {
                instance.objectLayer = EditorGUILayout.TextField("Game Layer: ", instance.objectLayer);
            }
            else if (instance.SearchBy == Collector.ObjectSearchType.Tag)
            {
                instance.objectTag = EditorGUILayout.TextField("Game Tag: ", instance.objectTag);
            }
            else if (instance.SearchBy == Collector.ObjectSearchType.Name)
            {
                instance.objectName = EditorGUILayout.TextField("Object Name [(contains)]: ", instance.objectName);
            }
        }
        else if (instance.ObjectType == Collector.ObjectClass.Entity)
        {
            instance.theEntity = (Entity)EditorGUILayout.ObjectField("Entity: ", instance.theEntity, typeof(Entity), true);
        }
        else if (instance.ObjectType == Collector.ObjectClass.Transform)
        {
            instance.theTransform = (Transform)EditorGUILayout.ObjectField("Transform: ", instance.theTransform, typeof(Transform), true);
        }
        

        EditorGUILayout.HelpBox("Select search scope", MessageType.None);
        instance.Scope = (Collector.SearchScope)EditorGUILayout.EnumPopup("Object Type", instance.Scope);
        //If Parent selected, ask for the parent object

        EditorGUILayout.HelpBox("Initiate Search", MessageType.None);
        if (GUILayout.Button("Build List"))
        {

        }

        EditorGUILayout.HelpBox("Available List operations", MessageType.None);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Sort List"))
        {

        }
        
        if (GUILayout.Button("Clear List"))
        {

        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Some Feature"))
        {

        }

        if(GUILayout.Button("Some Feature"))
        {

        }
        
        GUILayout.EndHorizontal();



        //base.OnInspectorGUI();
    }
}
