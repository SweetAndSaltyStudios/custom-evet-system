using UnityEngine;
using UnityEngine.EventSystems;

public class CustomEventSystem : EventSystem
{
    public void DebugMessage(GameObject gameObject)
    {
        Debug.Log(gameObject.name, gameObject);
    }
}
