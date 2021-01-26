using CustomUI.Selectables;
using UnityEditor;
using UnityEditor.UI;

namespace CustomUI.Editor.Selectables
{
    [CustomEditor(typeof(CustomButton)), CanEditMultipleObjects]
public class UIToggleEditor : ToggleEditor
{
    private SerializedProperty OnSelect_Event = default;
    private SerializedProperty OnDeselect_Event = default;
    private SerializedProperty OnCancel_Event = default;

    protected override void OnEnable()
    {
        base.OnEnable();

        OnSelect_Event = serializedObject.FindProperty("OnSelect_Event");
        OnDeselect_Event = serializedObject.FindProperty("OnDeselect_Event");
        OnCancel_Event = serializedObject.FindProperty("OnCancel_Event");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.PropertyField(OnSelect_Event, true);
        EditorGUILayout.PropertyField(OnDeselect_Event, true);
        EditorGUILayout.PropertyField(OnCancel_Event, true);

        serializedObject.ApplyModifiedProperties();
    }
}

}