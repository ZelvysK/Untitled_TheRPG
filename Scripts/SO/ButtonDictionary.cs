using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ButtonDictionary", menuName = "Custom/Button Dictionary")]
public class ButtonDictionary : ScriptableObject
{
    [SerializeField]
    public List<ButtonData> buttonDataList;

    private Dictionary<TabButtons, Button> buttonDictionary;

    public Dictionary<TabButtons, Button> GetButtonDictionary() {
        if (buttonDictionary == null)
        {
            buttonDictionary = new Dictionary<TabButtons, Button>();
            foreach (var buttonData in buttonDataList)
            {
                buttonDictionary[buttonData.type] = buttonData.button;
            }
        }
        return buttonDictionary;
    }

    [Serializable]
    public class ButtonData
    {
        public TabButtons type;
        public Button button;
    }
}
