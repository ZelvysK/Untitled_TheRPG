using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUITab : MonoBehaviour
{
    public static BaseUITab Instance { get; private set; }
    //[SerializeField] private Entity entity;

    [SerializeField] private GameObject characterTab;
    [SerializeField] private GameObject inventoryTab;
    [SerializeField] private GameObject mapTab;
    [SerializeField] private GameObject skillsTab;
    [SerializeField] private GameObject questsTab;
    [SerializeField] private GameObject settingsTab;


    //Tab switching buttons
    [SerializeField] public Button characterTabButton;
    [SerializeField] public Button inventoryTabButton;
    [SerializeField] public Button mapTabButton;
    [SerializeField] public Button skillsTabButton;
    [SerializeField] public Button questsTabButton;
    [SerializeField] public Button settingsTabButton;

    private void Awake() {
        Instance = this;

        //Tab swhitching buttons
        characterTabButton.onClick.AddListener(() =>
        {
            StatsTabUI.StatInstance.Show();
            inventoryTab.gameObject.SetActive(false);
            mapTab.gameObject.SetActive(false);
            skillsTab.gameObject.SetActive(false);
            questsTab.gameObject.SetActive(false);
            settingsTab.gameObject.SetActive(false);
        });
        inventoryTabButton.onClick.AddListener(() =>
        {
            StatsTabUI.StatInstance.Hide();
            inventoryTab.gameObject.SetActive(true);
            mapTab.gameObject.SetActive(false);
            skillsTab.gameObject.SetActive(false);
            questsTab.gameObject.SetActive(false);
            settingsTab.gameObject.SetActive(false);
        });
        mapTabButton.onClick.AddListener(() =>
        {
            StatsTabUI.StatInstance.Hide();
            inventoryTab.gameObject.SetActive(false);
            mapTab.gameObject.SetActive(true);
            skillsTab.gameObject.SetActive(false);
            questsTab.gameObject.SetActive(false);
            settingsTab.gameObject.SetActive(false);
        });
        skillsTabButton.onClick.AddListener(() =>
        {
            StatsTabUI.StatInstance.Hide();
            inventoryTab.gameObject.SetActive(false);
            mapTab.gameObject.SetActive(false);
            skillsTab.gameObject.SetActive(true);
            questsTab.gameObject.SetActive(false);
            settingsTab.gameObject.SetActive(false);
        });
        questsTabButton.onClick.AddListener(() =>
        {
            StatsTabUI.StatInstance.Hide();
            inventoryTab.gameObject.SetActive(false);
            mapTab.gameObject.SetActive(false);
            skillsTab.gameObject.SetActive(false);
            questsTab.gameObject.SetActive(true);
            settingsTab.gameObject.SetActive(false);
        });
        settingsTabButton.onClick.AddListener(() =>
        {
            StatsTabUI.StatInstance.Hide();
            inventoryTab.gameObject.SetActive(false);
            mapTab.gameObject.SetActive(false);
            skillsTab.gameObject.SetActive(false);
            questsTab.gameObject.SetActive(false);
            settingsTab.gameObject.SetActive(true);
        });
    }

    public void Show() { gameObject.SetActive(true); }

    public void Hide() { gameObject.SetActive(false); }
}
