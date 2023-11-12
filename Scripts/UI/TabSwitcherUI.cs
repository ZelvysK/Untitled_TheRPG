using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabSwitcherUI : MonoBehaviour
{
    //REFERENCES
    //Tabs to switch
    [SerializeField] private List<BaseUITab> tabsList;
    //Tab switching buttons
    [SerializeField] private List<Button> tabsButtonList;

    //VARIABLES
    private Button currentlySelectedButton;

    //PROPERTIES
    public Button CurrentlySelectedButton => currentlySelectedButton;

    private void Awake() {
        // Initialize tab buttons
        foreach (var button in tabsButtonList)
        {
            button.onClick.AddListener(() =>
            {
                // Find the corresponding tab and show it
                string buttonName = button.name.Replace("Button", string.Empty);
                ShowTab(buttonName);
                currentlySelectedButton = button;
            });
        }

        // Hide all tabs at the start
        HideAllTabs();
    }
    private void HideAllTabs() => tabsList.ForEach(tab => tab.Hide());

    private void ShowTab(string buttonName) {
        // Hide all tabs first
        HideAllTabs();

        // Find the corresponding tab by name
        BaseUITab tabToActivate = tabsList.Find(tab => tab.TabName == buttonName);

        if (tabToActivate != null)
        {
            tabToActivate.Show();
        }
    }
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
    public void SelectTabButton(string tabName) {
        // Find the corresponding tab button by name and simulate a click
        Button tabButton = tabsButtonList.Find(button => button.name == tabName + "Button");
        if (tabButton != null)
        {
            tabButton.Select();
        }
    }
}
