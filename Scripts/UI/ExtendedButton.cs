using UnityEditor.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ExtendedButton : Button
{
    public TabButtons ButtonType;
}

[CustomEditor(typeof(ExtendedButton))]
public class ExtendedButtonEditor : ButtonEditor
{
    public override void OnInspectorGUI() {
        var targetMyButton = (ExtendedButton)target;

        targetMyButton.ButtonType = (TabButtons)EditorGUILayout.EnumPopup("Button type:", targetMyButton.ButtonType);

        base.OnInspectorGUI();
    }
}