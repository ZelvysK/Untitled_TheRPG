using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BaseUITab : MonoBehaviour
{
    public static BaseUITab BaseUITabInstance { get; private set; }

    //Tabs to switch
    [SerializeField] private List<GameObject> tabsList;

    //Tab switching buttons
    [SerializeField] private List<Button> tabsButtonList;


    private void Awake() {
        BaseUITabInstance = this;

        //Use if instance breaks:

        //if (BaseUITabInstance != null)
        //{
        //    Debug.Log($"BaseUITabIsntance is set to {BaseUITabInstance}");
        //}
        //else
        //{
        //    BaseUITabInstance = this;
        //}

        for (int i = 0; i < tabsButtonList.Count; i++)
        {
            //Local var to catch index
            int buttonIndex = i;
            tabsButtonList[i].onClick.AddListener(() => ButtonClickHandler(buttonIndex));
        }

    }

    public void Show() { gameObject.SetActive(true); }

    public void Hide() { gameObject.SetActive(false); }

    private void ButtonClickHandler(int buttonIndex) {
        switch (buttonIndex)
        {
            case 0:
                HideAll();
                tabsList[buttonIndex].gameObject.SetActive(true);
                break;
            case 1:
                HideAll();
                tabsList[buttonIndex].gameObject.SetActive(true);
                break;
            case 2:
                HideAll();
                tabsList[buttonIndex].gameObject.SetActive(true);
                break;
            case 3:
                HideAll();
                tabsList[buttonIndex].gameObject.SetActive(true);
                break;
            case 4:
                HideAll();
                tabsList[buttonIndex].gameObject.SetActive(true);
                break;
            case 5:
                HideAll();
                tabsList[buttonIndex].gameObject.SetActive(true);
                break;
        }
    }

    private void HideAll() {
        foreach (var tab in tabsList)
        {
            tab.gameObject.SetActive(false);
        }
    }
}
