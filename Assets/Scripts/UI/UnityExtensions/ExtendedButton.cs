using UnityEditor.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ExtendedButton : Button
{
    public CharacterTabButton ButtonType;
}

[CustomEditor(typeof(ExtendedButton))]
public class ExtendedButtonEditor : ButtonEditor
{
    public override void OnInspectorGUI() {
        var targetMyButton = (ExtendedButton)target;

        targetMyButton.ButtonType = (CharacterTabButton)EditorGUILayout.EnumPopup("Button type:", targetMyButton.ButtonType);

        base.OnInspectorGUI();
    }
}