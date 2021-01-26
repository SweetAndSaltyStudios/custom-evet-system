using UnityEngine;

public class DebugHandler : MonoBehaviour
{
    public void DebugMessage(GameObject gameObject)
    {
        Debug.Log(gameObject.name, gameObject);
    }

    public void DebugMessage(string message)
    {
        Debug.Log(message);
    }
}
