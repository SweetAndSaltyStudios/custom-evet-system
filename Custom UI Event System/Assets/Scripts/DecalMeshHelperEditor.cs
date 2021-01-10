using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DuplicateComponentFinder))]
class DecalMeshHelperEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

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
