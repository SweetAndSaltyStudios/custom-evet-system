using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomSelectable : Selectable
{
    [SerializeField] private EventTrigger _eventTrigger = default;
    
    private CustomEventSystem currentEventSystem = default;
    private PointerEventData pointerEventData = default;

    protected override void Start()
    {
        base.Start();

        currentEventSystem = CustomEventSystem.Instance;
        pointerEventData = new PointerEventData(currentEventSystem);
    }

    private void Update()
    {
        if(currentEventSystem.IsSubmitButtonUp == false) return;
        if(currentEventSystem == null) return;
        if(currentEventSystem.currentSelectedGameObject != gameObject) return;

        foreach(var trigger in _eventTrigger.triggers)
        {
            trigger.callback.Invoke(pointerEventData);
        }
    }
}
