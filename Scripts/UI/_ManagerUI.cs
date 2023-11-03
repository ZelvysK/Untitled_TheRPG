using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class _ManagerUI : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    // Seperate script for each UI element to show/hide
    // This is for main control

    //Main Tabs
    public bool CharacterTabOpen { get; set; }
    public bool InventoryTabOpen { get; set; }
    public bool MapTabOpen { get; set; }
    public bool QuestsTabOpen { get; set; }
    public bool SkillsTabOpen { get; set; }
    public bool SettingsTabOpen { get; set; }


    //Base for all tabs
    private bool anyTabOpen;

    private void Awake() {
        HudUI.Instance.Show();

        anyTabOpen = false;
        BaseUITab.Instance.Hide();

        HideAllMenuTabs();

    }

    private void Start() {
        //Test UI
        gameInput.OnExperienceTestOpened += GameInput_OnExperienceTest;

        //Main UI tabs
        gameInput.OnCharacterTabOpened += GameInput_OnCharacterTabOpened;
        gameInput.OnInventoryTabOpened += GameInput_OnInventoryTabOpened;
        gameInput.OnMapTabOpened += GameInput_OnMapTabOpened;
        gameInput.OnQuestsTabOpened += GameInput_OnQuestsTabOpened;
        gameInput.OnSkillsTabOpened += GameInput_OnSkillsTabOpened;
        gameInput.OnSettingsTabOpened += GameInput_OnSettingsTabOpened;
    }

    private void GameInput_OnSettingsTabOpened(object sender, System.EventArgs e) {
        if (!SettingsTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            //StatsTabUI.Instance.ShowStats();
            SettingsTabOpen = true;
        }
        else if (anyTabOpen && !SettingsTabOpen)
        {
            HideAllMenuTabs();

            //Show SettingsTab
            SettingsTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            //StatsTabUI.Instance.HideStats();
            SettingsTabOpen = false;
        }
    }

    private void GameInput_OnSkillsTabOpened(object sender, System.EventArgs e) {
        if (!SkillsTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            //StatsTabUI.Instance.ShowStats();
            SkillsTabOpen = true;
        }
        else if (anyTabOpen && !SkillsTabOpen)
        {
            HideAllMenuTabs();

            //Show SkillsTab
            SkillsTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            //StatsTabUI.Instance.HideStats();
            SkillsTabOpen = false;
        }
    }

    private void GameInput_OnQuestsTabOpened(object sender, System.EventArgs e) {
        if (!QuestsTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            QuestsTabUI.QuestsInstance.Show();
            QuestsTabOpen = true;
        }
        else if (anyTabOpen && !QuestsTabOpen)
        {
            HideAllMenuTabs();

            QuestsTabUI.QuestsInstance.Show();
            QuestsTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            QuestsTabUI.QuestsInstance.Hide();
            QuestsTabOpen = false;
        }
    }

    private void GameInput_OnMapTabOpened(object sender, System.EventArgs e) {
        if (!MapTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            //StatsTabUI.Instance.ShowStats();
            MapTabOpen = true;
        }
        else if (anyTabOpen && !MapTabOpen)
        {
            HideAllMenuTabs();

            //Show MapTab
            MapTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            //StatsTabUI.Instance.HideStats();
            MapTabOpen = false;
        }
    }

    private void GameInput_OnInventoryTabOpened(object sender, System.EventArgs e) {
        if (!InventoryTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            //StatsTabUI.Instance.ShowStats();
            InventoryTabOpen = true;
        }
        else if (anyTabOpen && !InventoryTabOpen)
        {
           HideAllMenuTabs();

            //Show InventoryTab
            InventoryTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            //StatsTabUI.Instance.HideStats();
            InventoryTabOpen = false;
        }
    }

    private void GameInput_OnCharacterTabOpened(object sender, System.EventArgs e) {
        if (!CharacterTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            StatsTabUI.StatInstance.Show();
            CharacterTabOpen = true;
        }
        else if (anyTabOpen && !CharacterTabOpen)
        {
            HideAllMenuTabs();

            //Show CharacterTab
            StatsTabUI.StatInstance.Show();
            CharacterTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            StatsTabUI.StatInstance.Hide();
            CharacterTabOpen = false;

        }
    }


    private void GameInput_OnExperienceTest(object sender, System.EventArgs e) {
        Debug.Log("Experience test is Open!");
        ExperienceTest.Instance.Show();
    }

    private void HideAllMenuTabs() {

        CharacterTabOpen = false;
        StatsTabUI.StatInstance.Hide();

        QuestsTabOpen = false;
        QuestsTabUI.QuestsInstance.Hide();

        //Hide Others
        InventoryTabOpen = false;
        MapTabOpen = false;
        SkillsTabOpen = false;
        SettingsTabOpen = false;
    }

}
