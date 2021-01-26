﻿using System;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CustomEditor(typeof(CustomButton)), CanEditMultipleObjects]
public class UIButtonEditor : ButtonEditor
{
    private SerializedProperty OnSelect_Event = default;

    protected override void OnEnable()
    {
        base.OnEnable();
     
        OnSelect_Event = serializedObject.FindProperty("OnSelect_Event");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(OnSelect_Event, true);
        serializedObject.ApplyModifiedProperties();
    }
}


public class CustomButton : Button
{
    [Serializable]
    public class OnSelectEvent : UnityEvent { }

    public OnSelectEvent OnSelect_Event;
    public event Action OnDeselect_Event = () => { };

    #region UNITY BASE METHOD OVERRIDES
    //public override bool IsActive()
    //{
    //    return base.IsActive();
    //    Debug.Log($"{name}: IsActive", gameObject);
    //}
    //protected override void Awake()
    //{
    //    base.Awake();
    //    Debug.Log($"{name}: Awake", gameObject);
    //}
    //protected override void OnEnable()
    //{
    //    base.OnEnable();
    //    Debug.Log($"{name}: OnEnable", gameObject);
    //}
    //protected override void Start()
    //{
    //    base.Start();
    //    Debug.Log($"{name}: Start", gameObject);
    //}
    //protected override void OnDisable()
    //{
    //    base.OnDisable();
    //    Debug.Log($"{name}: OnDisable", gameObject);
    //}
    //protected override void OnDestroy()
    //{
    //    base.OnDestroy();
    //    Debug.Log($"{name}: OnDestroy", gameObject);
    //}
    //protected override void OnValidate()
    //{
    //    base.OnValidate();
    //    Debug.Log($"{name}: OnValidate", gameObject);
    //}
    //protected override void OnTransformParentChanged()
    //{
    //    base.OnTransformParentChanged();
    //    Debug.Log($"{name}: OnTransformParentChanged", gameObject);
    //}
    //protected override void OnDidApplyAnimationProperties()
    //{
    //    base.OnDidApplyAnimationProperties();
    //    Debug.Log($"{name}: OnDidApplyAnimationProperties", gameObject);
    //}
    //protected override void OnBeforeTransformParentChanged()
    //{
    //    base.OnBeforeTransformParentChanged();
    //    Debug.Log($"{name}: OnBeforeTransformParentChanged", gameObject);
    //}
    //protected override void OnRectTransformDimensionsChange()
    //{
    //    base.OnRectTransformDimensionsChange();
    //    Debug.Log($"{name}: OnRectTransformDimensionsChange", gameObject);
    //}
    //protected override void OnCanvasGroupChanged()
    //{
    //    base.OnCanvasGroupChanged();
    //    Debug.Log($"{name}: OnCanvasGroupChanged", gameObject);
    //}
    //protected override void OnCanvasHierarchyChanged()
    //{
    //    base.OnCanvasHierarchyChanged();
    //    Debug.Log($"{name}: OnCanvasHierarchyChanged", gameObject);
    //}
    //protected override void Reset()
    //{
    //    base.Reset();
    //    Debug.Log($"{name}: Reset", gameObject);
    //}
    #endregion UNITY BASE METHOD OVERRIDES

    #region UNITY EVENT DATA EVENTS
    public override void OnSubmit(BaseEventData eventData)
    {
        base.OnSubmit(eventData);

        Debug.Log($"{name}: OnSubmit", gameObject);
    }
    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);

        OnSelect_Event?.Invoke();

        //Debug.Log($"{name}: OnSelect", gameObject);
    }
    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);

        OnDeselect_Event?.Invoke();
        // Debug.Log($"{name}: OnDeselect", gameObject);
    }
   
    //public override void OnPointerClick(PointerEventData eventData)
    //{
    //    base.OnPointerClick(eventData);
    //    Debug.Log($"{name}: OnPointerClick", gameObject);
    //}
    //public override void OnPointerDown(PointerEventData eventData)
    //{
    //    base.OnPointerDown(eventData);
    //    Debug.Log($"{name}: OnPointerDown", gameObject);
    //}
    //public override void OnPointerEnter(PointerEventData eventData)
    //{
    //    base.OnPointerEnter(eventData);
    //    Debug.Log($"{name}: OnPointerEnter", gameObject);
    //}
    //public override void OnPointerExit(PointerEventData eventData)
    //{
    //    base.OnPointerExit(eventData);
    //    Debug.Log($"{name}: OnPointerExit", gameObject);
    //}
    //public override void OnPointerUp(PointerEventData eventData)
    //{
    //    base.OnPointerUp(eventData);
    //    Debug.Log($"{name}: OnPointerUp", gameObject);
    //}
    //public override void OnMove(AxisEventData eventData)
    //{
    //    base.OnMove(eventData);
    //    Debug.Log($"{name}: OnMove", gameObject);
    //}
    #endregion UNITY EVENT DATA EVENTS

    #region SELECTABLE METHOD OVERRIDES
    //public override Selectable FindSelectableOnDown()
    //{
    //    Debug.Log($"{name}: FindSelectableOnDown", gameObject);
    //    return base.FindSelectableOnDown();
    //}
    //public override Selectable FindSelectableOnLeft()
    //{
    //    Debug.Log($"{name}: FindSelectableOnLeft", gameObject);
    //    return base.FindSelectableOnLeft();
    //}
    //public override Selectable FindSelectableOnRight()
    //{
    //    Debug.Log($"{name}: FindSelectableOnRight", gameObject);
    //    return base.FindSelectableOnRight();
    //}
    //public override Selectable FindSelectableOnUp()
    //{
    //    Debug.Log($"{name}: FindSelectableOnUp", gameObject);
    //    return base.FindSelectableOnUp();
    //}
    //public override bool IsInteractable()
    //{
    //    Debug.Log($"{name}: IsInteractable", gameObject);
    //    return base.IsInteractable();
    //}
    //protected override void DoStateTransition(SelectionState state, bool instant)
    //{
    //    base.DoStateTransition(state, instant);
    //    Debug.Log($"{name}: DoStateTransition", gameObject);
    //}
    //protected override void InstantClearState()
    //{
    //    base.InstantClearState();
    //    Debug.Log($"{name}: InstantClearState", gameObject);
    //}
    #endregion SELECTABLE METHOD OVERRIDES

    #region BASE OBJECT EVENT OVERRIDES
    //public override bool Equals(object other)
    //{
    //    return base.Equals(other);
    //    Debug.Log($"{name}: Equals", gameObject);
    //}
    //public override string ToString()
    //{
    //    return base.ToString();
    //    Debug.Log($"{name}: ToString", gameObject);
    //}
    //public override int GetHashCode()
    //{
    //    return base.GetHashCode();
    //    Debug.Log($"{name}: GetHashCode", gameObject);
    //}
    #endregion BASE OBJECT EVENT OVERRIDES

    //public override void Select()
    //{
    //    base.Select();
    //    Debug.Log($"{name}: Select", gameObject);
    //}
}