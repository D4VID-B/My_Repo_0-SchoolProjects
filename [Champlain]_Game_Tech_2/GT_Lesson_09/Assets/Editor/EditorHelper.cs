using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorHelper
{
    public static void drawLine(Color color, int thiccness = 2, int padding = 10)
    {
        Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thiccness));
        rect.height = thiccness;
        rect.y += padding / 2;
        rect.x -= 2;
        rect.width += 6;

        EditorGUI.DrawRect(rect, color);
    }
}
