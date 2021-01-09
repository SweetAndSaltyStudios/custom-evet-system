using UnityEngine;
using UnityEngine.EventSystems;

public class CustomEventSystem : EventSystem
{
    public void DebugMessage(GameObject gameObject)
    {
        Debug.Log(gameObject.name, gameObject);
    }

    public void DebugMessage(string message)
    {
        Debug.Log(message);
    }

    protected override void Start()
    {
        base.Start();

        if(firstSelectedGameObject == null)
        {
            SetSelectedGameObject(gameObject);
        }
    }

    protected override void Update()
    {
        base.Update();

    }
}
