using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnAtPos))]
public class SpawnerAtPosEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("A tool to help with instantiation various objects. Has multiple spawning modes and can spawn different objects.", MessageType.Info);

        SpawnAtPos instance = (SpawnAtPos)target;

        EditorGUILayout.HelpBox("Choose what kind of object to spawn:" , MessageType.None);
        instance.Type = (SpawnAtPos.ObjectType)EditorGUILayout.EnumPopup("Object Type", instance.Type);

        EditorGUILayout.HelpBox("Choose where and how you want the object to appear:", MessageType.None);
        instance.Choice = (SpawnAtPos.SpawnChoice)EditorGUILayout.EnumPopup("Spawner Type", instance.Choice);

        if(instance.Choice == SpawnAtPos.SpawnChoice.CustomTransform)
        {
            instance.custonSpawnPosition = EditorGUILayout.Vector3Field("Position", instance.custonSpawnPosition);
            instance.customSpawnRotation = EditorGUILayout.Vector3Field("Rotation", instance.customSpawnRotation);
            instance.customSpawnScale = EditorGUILayout.Vector3Field("Scale", instance.customSpawnScale);

        }
        else
        {
            EditorGUILayout.HelpBox("Functionality not yet implemented!", MessageType.Warning);
        }



        if (GUILayout.Button("Spawn"))
        {
            instance.spawn();
        }

        //base.OnInspectorGUI();
    }

    
}
