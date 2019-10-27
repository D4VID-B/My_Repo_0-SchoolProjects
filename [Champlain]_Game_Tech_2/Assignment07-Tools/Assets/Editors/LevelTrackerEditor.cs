using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelTracker))]

public class LevelTrackerEditor : Editor
{ 
    public override void OnInspectorGUI()
    {

        EditorGUILayout.HelpBox("The level tool from class, but with some added functionality. Could be potentially expanded to include Health and Mana/Stamina Tracking", MessageType.Info);

        LevelTracker instance = target as LevelTracker; //cast target as a LevelScript ==> (LevelScript)target

        instance.Type = (LevelTracker.StatType)EditorGUILayout.EnumPopup("Stat to Track", instance.Type);

        if(instance.Type == LevelTracker.StatType.Level)
        {
            GUIContent boosterContent = new GUIContent("Boost Amount");

            instance.experience = EditorGUILayout.IntField("Experience", instance.experience);
            instance.boost = EditorGUILayout.IntField(boosterContent, instance.boost);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Boost Level"))
            {
                instance.boostLevel(instance.boost);
            }

            if (GUILayout.Button("Reset Level"))
            {
                instance.resetLevel();
            }
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.LabelField("Level", instance.level.ToString());
        }
        else if(instance.Type == LevelTracker.StatType.Stamina)
        {
            EditorGUILayout.HelpBox("Stamina Tracker not yet implemented!", MessageType.Warning);
        }
        else if (instance.Type == LevelTracker.StatType.OtherStat)
        {
            EditorGUILayout.HelpBox("Placeholder for other features.", MessageType.Info);

        }

    }
}

