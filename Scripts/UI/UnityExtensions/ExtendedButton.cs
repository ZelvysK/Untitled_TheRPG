using UnityEditor.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ExtendedButton : Button
{
    public CharacterTabButtons ButtonType;
}

[CustomEditor(typeof(ExtendedButton))]
public class ExtendedButtonEditor : ButtonEditor
{
    public override void OnInspectorGUI() {
        var targetMyButton = (ExtendedButton)target;

        targetMyButton.ButtonType = (CharacterTabButtons)EditorGUILayout.EnumPopup("Button type:", targetMyButton.ButtonType);

        base.OnInspectorGUI();
    }
}