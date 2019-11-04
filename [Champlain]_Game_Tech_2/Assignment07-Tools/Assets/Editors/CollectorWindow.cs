using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[/*CustomEditor(typeof(Collector)),*/ CanEditMultipleObjects]
public class CollectorWindow : EditorWindow
{

    public Collector instance;

    bool assignToParent = false;
    bool renameAll = false;
    bool searchingInParent = false;

    string listString;

    [MenuItem("Window/Collector")]
    static void showWindow()
    {
        EditorWindow.GetWindow(typeof(CollectorWindow));
    }


    private void OnGUI()
    {
        EditorGUILayout.HelpBox("A simplified accessor of the list class, to speed up the collection and processing of various user-defined objects.", MessageType.Info);

        instance = (Collector)EditorGUILayout.ObjectField("Collector Script", instance, typeof(Collector), true);

        EditorGUILayout.HelpBox("Select the main search parameter:", MessageType.None);
        instance.ObjectType = (Collector.ObjectClass)EditorGUILayout.EnumPopup("Object Type", instance.ObjectType);
        //Display any relevant information, depending on type choice. E.g: A string input box

        if (instance.ObjectType == Collector.ObjectClass.GameObject)
        {
            instance.SearchBy = (Collector.ObjectSearchType)EditorGUILayout.EnumPopup("Search by ...: ", instance.SearchBy);

            if (instance.SearchBy == Collector.ObjectSearchType.Layer)
            {
                instance.objectLayer = EditorGUILayout.IntSlider("Game Layer: ", instance.objectLayer, 8, 31);
            }
            else if (instance.SearchBy == Collector.ObjectSearchType.Tag)
            {
                instance.objectTag = EditorGUILayout.TextField("Game Tag: ", instance.objectTag);
            }
            else if (instance.SearchBy == Collector.ObjectSearchType.Name)
            {
                instance.objectName = EditorGUILayout.TextField("Object Name Contains: ", instance.objectName);
            }

            int index = 0;
            foreach (GameObject obj in instance.objectList)
            {
                EditorGUILayout.LabelField("Object List Position " + index, obj.ToString());
                index++;
            }
            EditorGUILayout.LabelField("List Size: ", instance.objectList.Count.ToString());

            

        }
        else if (instance.ObjectType == Collector.ObjectClass.Entity)
        {
            EditorGUILayout.LabelField("List Size: ", instance.entityList.Count.ToString());
            int index = 0;
            foreach (Entity obj in instance.entityList)
            {
                listString = obj.ToString();
                EditorGUILayout.LabelField("Entity List Position " + index, listString);
                index++;
            }

        }
        

        EditorGUILayout.HelpBox("Select search scope", MessageType.None);
        instance.Scope = (Collector.SearchScope)EditorGUILayout.EnumPopup("Object Type", instance.Scope);
        
        if(instance.Scope == Collector.SearchScope.Search_Scene_Root_Only)
        {
            searchingInParent = false;
        }
        else if(instance.Scope == Collector.SearchScope.Search_Scene_ALL_Parents)
        {
            searchingInParent = false;
        }
        else
        {
            searchingInParent = true;
            instance.parent = (GameObject)EditorGUILayout.ObjectField("Parent to Search: ", instance.parent, typeof(GameObject), true);
        }

        EditorGUILayout.HelpBox("Initiate Search", MessageType.None);
        if (GUILayout.Button("Build List"))
        {
            
            if(instance.ObjectType == Collector.ObjectClass.Entity)
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
            instance.sortList(instance.ObjectType);
            assignToParent = false;
            renameAll = false;
        }

        if (GUILayout.Button("Clear List"))
        {
            instance.clearList(instance.ObjectType);
            assignToParent = false;
            renameAll = false;
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Rename All"))
        {
            assignToParent = false;
            renameAll = true;
        }
        
        //Credit to Gregory Miller for giving me the idea for this function
        if (GUILayout.Button("Assign to Parent"))
        {
            renameAll = false;
            assignToParent = true;
        }
       

        GUILayout.EndHorizontal();

        EditorGUILayout.EndToggleGroup();

        if(renameAll)
        {
            instance.baseName = EditorGUILayout.TextField("New Base Name: ", instance.baseName);
            instance.startIndex = EditorGUILayout.DelayedIntField("Starting Index: ", instance.startIndex);

            if(GUILayout.Button("Rename"))
            {
                if(instance.objectListEmpty)
                {
                    foreach (GameObject obj in instance.objectList)
                    {
                        obj.name = instance.baseName + "_" + instance.startIndex;
                        instance.startIndex++;
                    }
                }

                if(instance.entityListEmpty)
                {
                    foreach (Entity obj in instance.entityList)
                    {
                        obj.name = instance.baseName + "_" + instance.startIndex;
                        instance.startIndex++;
                    }
                }

                
            }
        }

        if(assignToParent)
        {
            instance.parent = (GameObject)EditorGUILayout.ObjectField("Parent Object", instance.parent, typeof(GameObject), true);

            if(GUILayout.Button("Assign"))
            {
                if(instance.parent == null)//Assign to root
                {

                    if (instance.objectListEmpty)
                    {
                        foreach (GameObject obj in instance.objectList)
                        {
                            obj.transform.parent = null;

                        }
                    }

                    if (instance.entityListEmpty)
                    {
                        foreach (Entity obj in instance.entityList)
                        {
                            obj.transform.parent = null;

                        }
                    }
                }
                else
                {

                    if (instance.objectListEmpty)
                    {
                        foreach (GameObject obj in instance.objectList)
                        {
                            obj.transform.parent = instance.parent.transform;

                        }
                    }

                    if (instance.entityListEmpty)
                    {
                        foreach (Entity obj in instance.entityList)
                        {
                            obj.transform.parent = instance.parent.transform;

                        }
                    }
                }

            }
        }

        //this.Repaint();
    }
}
