using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomSelectable : Selectable
{
    [SerializeField] private EventTrigger eventTrigger;
    [SerializeField] private string submitLabel = "Submit";
    
    private EventSystem currentEventSystem = default;

    protected override void Start()
    {
        base.Start();

        currentEventSystem = EventSystem.current;
    }

    private void Update()
    {
        if(currentEventSystem == null) return;
        if(currentEventSystem.currentSelectedGameObject != gameObject) return;
        if(Input.GetButtonUp(submitLabel) == false) return;

        ExecuteEvents.Execute(
               gameObject,
               new PointerEventData(EventSystem.current),
               ExecuteEvents.pointerClickHandler);
    }
}
