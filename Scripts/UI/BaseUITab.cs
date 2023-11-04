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
        /*if (BaseUITabInstance != null)
        {
            Debug.Log($"BaseUITabIsntance is set to {BaseUITabInstance}");
        }
        else
        {
            BaseUITabInstance = this;
        }*/

        for (int i = 0; i < tabsButtonList.Count; i++)
        {
            //Local var to catch index
            int buttonIndex = i;
            tabsButtonList[i].onClick.AddListener(() =>
            {
                HideAll();
                tabsList[i].gameObject.SetActive(true);
            });
        }
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void HideAll() => tabsList.ForEach(tab => tab.gameObject.SetActive(false));
}
