using System;
using UnityEngine;

[Serializable]
public class DuplicatePointer
{
    [HideInInspector] public string Name = default;

    [SerializeField] private GameObject contextGameObject = default;
    [SerializeField] private Component[] duplicateComponents = default;

    public DuplicatePointer(GameObject contextGameObject, Component[] duplicateComponents)
    {
        Name = contextGameObject.name;

        this.contextGameObject = contextGameObject;
        this.duplicateComponents = duplicateComponents;
    }

    public void RemoveDuplicates()
    {
        if(duplicateComponents == null || duplicateComponents.Length == 0) return;

        foreach(var duplicateComponent in duplicateComponents)
        {
#if UNITY_EDITOR
            UnityEngine.Object.DestroyImmediate(duplicateComponent);
#else
            UnityEngine.Object.Destroy(duplicateComponent);
#endif
        }

        duplicateComponents = null;
    }
}
