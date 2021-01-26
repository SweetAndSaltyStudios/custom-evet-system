using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuplicateComponentFinder : MonoBehaviour
{
    [SerializeField] private List<DuplicatePointer> duplicatePointers = default; 

    private bool isCreated = default;

    public void GetAllComponentsInScene()
    {
        if(isCreated)
        {
            return;
        }


        isCreated = true;
    }

    public void GetDuplicateComponentsInScene()
    {
        if(isCreated)
        {
            return;
        }

        if(duplicatePointers == null)
        { 
            duplicatePointers = new List<DuplicatePointer>();
        }

        var rootGameObjects = SceneManager.GetActiveScene()
            .GetRootGameObjects();

        foreach(var root in rootGameObjects)
        {
            foreach(var child in root.GetComponentsInChildren<Transform>(true))
            {
                HandleDuplicates(child.gameObject);
            }
        }

        isCreated = true;
    }

    private void HandleDuplicates(GameObject gameObject)
    {
        var duplicates = GetDuplicates(gameObject);

        if(duplicates == null || duplicates.Length == 0) return;
        
        duplicatePointers.Add(new DuplicatePointer(gameObject, duplicates));
    }

    private Component[] GetDuplicates(GameObject gameObject)
    {
        var components = gameObject.GetComponents<Component>();

        var duplicateComponents = components
            .GroupBy(s => s.GetType())
            .SelectMany(x => x.Skip(1))
            .ToArray();

        return duplicateComponents;
    }

    public void Clear()
    {
        if(duplicatePointers != null)
        {
            duplicatePointers.Clear();
            duplicatePointers = null;
        }

        isCreated = false;
    }

    public void Remove()
    {
        if(duplicatePointers != null)
        {
            foreach(var duplicatePointer in duplicatePointers)
            {
                duplicatePointer.RemoveDuplicates();
            }
        }
    }
}
