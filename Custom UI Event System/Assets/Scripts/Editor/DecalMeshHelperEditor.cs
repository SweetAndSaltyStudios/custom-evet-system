using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DuplicateComponentFinder))]
class DecalMeshHelperEditor : Editor
{
    public enum ACCEPT
    {
        FALSE,
        TRUE
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Get Duplicates"))
        {
            var duplicateComponentFinder = target as DuplicateComponentFinder;

            if(duplicateComponentFinder != null)
            {
                duplicateComponentFinder.GetDuplicateComponentsInScene();
            }
        }

        if(GUILayout.Button("Clear"))
        {
            var duplicateComponentFinder = target as DuplicateComponentFinder;

            if(duplicateComponentFinder != null)
            {
                duplicateComponentFinder.Clear();
            }
        }

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();

        GUILayout.Space(10);

        GUI.backgroundColor = Color.red;

        if(GUILayout.Button("Remove"))
        {
            var duplicateComponentFinder = target as DuplicateComponentFinder;
            var display = ACCEPT.FALSE;
            var position = Input.mousePosition;

            var rect = new Rect(position, Vector2.one * 100);

            display = (ACCEPT)EditorGUI.EnumPopup(
                rect,
                "Show:",
                display);

            if(duplicateComponentFinder != null)
            {

                duplicateComponentFinder.Remove();
            }
        }
    }
}
