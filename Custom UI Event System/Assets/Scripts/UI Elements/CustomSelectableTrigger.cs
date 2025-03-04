﻿using CustomUI.EventSystems;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class CustomSelectableTrigger : Selectable
{
    private EventTrigger _eventTrigger = default;
    private CustomEventSystem currentEventSystem = default;
    private PointerEventData pointerEventData = default;

    protected override void Awake()
    {
        base.Awake();

        _eventTrigger = GetComponent<EventTrigger>();
    }

    protected override void Start()
    {
        base.Start();

        currentEventSystem = CustomEventSystem.Instance;
        pointerEventData = new PointerEventData(currentEventSystem);
    }

    private void Update()
    {
        if(currentEventSystem == null) return;
        if(currentEventSystem.IsSubmitButtonUp == false) return;
        if(currentEventSystem.currentSelectedGameObject != gameObject) return;

        foreach(var trigger in _eventTrigger.triggers)
        {
            trigger.callback.Invoke(pointerEventData);
        }
    }
}
