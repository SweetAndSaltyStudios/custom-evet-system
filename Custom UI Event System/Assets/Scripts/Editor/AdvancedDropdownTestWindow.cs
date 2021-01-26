using UnityEngine;

using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class AdvancedDropdownTestWindow : EditorWindow
{
    [MenuItem("Window/My Window")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        GetWindow(typeof(AdvancedDropdownTestWindow));
    }

    private void OnGUI()
    {
        var rect = GUILayoutUtility.GetRect(new GUIContent("Show"), EditorStyles.toolbarButton);
        
        if(GUI.Button(rect, new GUIContent("Show"), EditorStyles.toolbarButton))
        {
            var dropdown = new ComponentDropdow(new AdvancedDropdownState());
            dropdown.Show(rect);
        }
    }
}
