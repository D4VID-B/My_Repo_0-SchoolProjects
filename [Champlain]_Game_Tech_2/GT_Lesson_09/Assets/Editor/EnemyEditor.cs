using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyScript))]
[CanEditMultipleObjects]
public class EnemyEditor : Editor
{

    SerializedProperty damageProp;
    SerializedProperty armorProp;
    SerializedProperty weaponProp;

    private void OnEnable()
    {
        damageProp = serializedObject.FindProperty("damage");
        armorProp = serializedObject.FindProperty("armor");
        weaponProp = serializedObject.FindProperty("weapon");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EnemyScript instance = (EnemyScript)target;

        //instance.damage = EditorGUILayout.IntSlider("Damange", instance.damage, 0, 100);
        EditorGUILayout.IntSlider(damageProp, 0, 100, new GUIContent("damage"));

        if (!damageProp.hasMultipleDifferentValues)
            progressBar(damageProp.intValue /100f, "Damage");

        //instance.armor = EditorGUILayout.IntSlider("Armor", instance.armor, 0, 100);
        EditorGUILayout.IntSlider(armorProp, 0, 100, new GUIContent("Armor"));

        if (!armorProp.hasMultipleDifferentValues)
            progressBar(armorProp.intValue / 100f, "Armor");

        //bool allowSceneObject = !EditorUtility.IsPersistent(target);
        //instance.weapon = (GameObject)EditorGUILayout.ObjectField("Weapon", instance.weapon, typeof(GameObject), allowSceneObject);

        EditorGUILayout.PropertyField(weaponProp, new GUIContent("Weapon"));

        serializedObject.ApplyModifiedProperties();
        
        //base.OnInspectorGUI();
    }

    void progressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18f, 18f, "TextField");

        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
}
