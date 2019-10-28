using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangeNameWindow : EditorWindow
{
    GameObject[] gameObjects;
    int objectCount;
    string startName;
    string split = "_";
    int index;

    string tagName;


    [MenuItem("Tools/Rename Selected Objects")]
static void showWindow()
    {
        EditorWindow.GetWindow(typeof(ChangeNameWindow));
    }

    private void OnGUI()
    {

        tagName = EditorGUILayout.TextField("Object Tag", tagName);

        if(GUILayout.Button("Find Objects with Tag"))
        {
            findObjectsWithTag(tagName);
        }

        EditorHelper.drawLine(Color.red);

        EditorGUILayout.LabelField("Number Seleceted", gameObjects.Length.ToString());

        startName = EditorGUILayout.TextField("Starting Name", startName);

        index = EditorGUILayout.IntField("Starting index", index);

        EditorHelper.drawLine(Color.blue, 10);
        if (GUILayout.Button("Change Names"))
        {
            changeNames();
        }

        if(GUILayout.Button("Draw Line"))
        {
        }
    }

    private void Update()
    {
        gameObjects = Selection.gameObjects;

        if(gameObjects.Length != objectCount)
        {
            objectCount = gameObjects.Length;
            Repaint();
        }

    }

    void changeNames()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            int temp = i + index;
            gameObjects[i].name = startName + split + temp;
        }
    }

    void findObjectsWithTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        Selection.objects = objects;
    }

}
