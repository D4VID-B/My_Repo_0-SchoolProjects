﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[/*CustomEditor(typeof(Collector)),*/ CanEditMultipleObjects]
public class CollectorWindow : EditorWindow
{

    public Collector instance;

    bool assignToParent = false;
    bool renameAll = false;
    bool searchingInParent = false;

    string listString;
    string starter = "List Contains: ";

    [MenuItem("Window/Collector")]
    static void showWindow()
    {
        EditorWindow.GetWindow(typeof(CollectorWindow));
    }


    private void OnGUI()
    {
        EditorGUILayout.HelpBox("An incapsulation of the list class, to speed up the collection and processing of various user-defined objects.", MessageType.Info);

        instance = (Collector)EditorGUILayout.ObjectField("Collector Script", instance, typeof(Collector), true);

        EditorGUILayout.HelpBox("Select the main search parameter:", MessageType.None);
        instance.ObjectType = (Collector.ObjectClass)EditorGUILayout.EnumPopup("Object Type", instance.ObjectType);
        //Display any relevant information, depending on type choice. E.g: A string input box

        if (instance.ObjectType == Collector.ObjectClass.GameObject)
        {
            instance.SearchBy = (Collector.ObjectSearchType)EditorGUILayout.EnumPopup("Search by ...: ", instance.SearchBy);

            if (instance.SearchBy == Collector.ObjectSearchType.Layer)
            {
                instance.objectLayer = EditorGUILayout.TextField("Game Layer: ", instance.objectLayer);
                listString = starter;
                foreach (GameObject obj in instance.objectList)
                {
                    listString += " " + obj.ToString() + " \n";
                }

                EditorGUILayout.LabelField("Object List: ", listString);
            }
            else if (instance.SearchBy == Collector.ObjectSearchType.Tag)
            {
                instance.objectTag = EditorGUILayout.TextField("Game Tag: ", instance.objectTag);
                listString = starter;
                foreach (GameObject obj in instance.objectList)
                {
                    listString += " " + obj.ToString() + " \n";
                }

                EditorGUILayout.LabelField("Object List: ", listString);
            }
            else if (instance.SearchBy == Collector.ObjectSearchType.Name)
            {
                instance.objectName = EditorGUILayout.TextField("Object Name [(contains)]: ", instance.objectName);
                listString = starter;
                foreach (GameObject obj in instance.objectList)
                {
                    listString += " " + obj.ToString() + " \n";
                }

                EditorGUILayout.LabelField("Object List: ", listString);
            }
        }
        else if (instance.ObjectType == Collector.ObjectClass.Entity)
        {
            instance.theEntity = (Entity)EditorGUILayout.ObjectField("Entity: ", instance.theEntity, typeof(Entity), true);
            listString = starter;
            foreach (Entity obj in instance.entityList)
            {
                listString += " " + obj.ToString() + " \n";
            }

            EditorGUILayout.LabelField("Entity List: ", listString);
        }
        else if (instance.ObjectType == Collector.ObjectClass.Transform)
        {
            instance.theTransform = (Transform)EditorGUILayout.ObjectField("Transform: ", instance.theTransform, typeof(Transform), true);
            listString = starter;
            foreach (Transform obj in instance.transformList)
            {
                listString += " " + obj.ToString() + " \n";
            }

            EditorGUILayout.LabelField("Transform List: ", listString);
        }
        

        EditorGUILayout.HelpBox("Select search scope", MessageType.None);
        instance.Scope = (Collector.SearchScope)EditorGUILayout.EnumPopup("Object Type", instance.Scope);
        
        if(instance.Scope == Collector.SearchScope.Search_In_Parent)
        {
            searchingInParent = true;
            instance.parent = (GameObject)EditorGUILayout.ObjectField("Parent to Search: ", instance.parent, typeof(GameObject), true);
        }

        EditorGUILayout.HelpBox("Initiate Search", MessageType.None);
        if (GUILayout.Button("Build List"))
        {
            if(instance.ObjectType == Collector.ObjectClass.Transform && instance.theTransform != null)
            {
                instance.fillTransformList(searchingInParent);
            }
            else if(instance.ObjectType == Collector.ObjectClass.Entity && instance.theEntity != null)
            {
                instance.fillEntityList(searchingInParent);
            }
            else
            {
                if(instance.SearchBy == Collector.ObjectSearchType.Name)
                {
                    instance.fillObjectList(Collector.ObjectSearchType.Name, searchingInParent);
                }
                else if(instance.SearchBy == Collector.ObjectSearchType.Tag)
                {
                    instance.fillObjectList(Collector.ObjectSearchType.Tag, searchingInParent);
                }
                else if(instance.SearchBy == Collector.ObjectSearchType.Layer)
                {
                    instance.fillObjectList(Collector.ObjectSearchType.Layer, searchingInParent);
                }
            }
        }

        EditorGUILayout.HelpBox("Available List operations", MessageType.None);

        EditorGUILayout.BeginToggleGroup("Available List operations", instance.listEmpty);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Sort List"))
        {

        }

        if (GUILayout.Button("Clear List"))
        {

        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Rename All"))
        {
            renameAll = true;
        }

        if (GUILayout.Button("Assign to Parent"))
        {
            assignToParent = true;
        }

        GUILayout.EndHorizontal();

        EditorGUILayout.EndToggleGroup();

        if(renameAll)
        {
            instance.baseName = EditorGUILayout.TextField("New Base Name: ", instance.baseName);
            instance.startIndex = EditorGUILayout.DelayedIntField("Starting Index: ", instance.startIndex);
        }

        if(assignToParent)
        {
            instance.parent = (GameObject)EditorGUILayout.ObjectField("Parent Object", instance.parent, typeof(GameObject), true);
        }
    }
}
