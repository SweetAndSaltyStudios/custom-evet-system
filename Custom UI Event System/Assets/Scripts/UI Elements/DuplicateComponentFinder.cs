using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuplicateComponentFinder : MonoBehaviour
{
    [SerializeField] private List<DuplicatePointer> duplicatePointers = default; 

    private bool isCreated = default;

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

        var rootGameObjects =SceneManager.GetActiveScene()
            .GetRootGameObjects();

        foreach(var rootGameObject in rootGameObjects)
        {
            var components = rootGameObject.GetComponents<Component>();

            var duplicateComponents = components
                .GroupBy(s => s.GetType())
                .SelectMany(x => x.Skip(1)).ToArray();

            if(duplicateComponents == null || duplicateComponents.Length == 0)
            {
                continue;
            }

            duplicatePointers.Add(new DuplicatePointer(rootGameObject, duplicateComponents));
        }

        isCreated = true;
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
