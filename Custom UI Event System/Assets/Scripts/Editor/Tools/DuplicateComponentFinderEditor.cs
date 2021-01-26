using UnityEditor;
using UnityEngine;

namespace CustomUI.Tools
{
    [CustomEditor(typeof(DuplicateComponentFinder))]
    class DuplicateComponentFinderEditor : UnityEditor.Editor
    {
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

                if(duplicateComponentFinder != null)
                {
                    duplicateComponentFinder.Remove();
                }
            }
        }
    }
}