using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// This is for main UI control
public class _ManagerUI : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;

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
        BaseUITab.BaseUITabInstance.Hide();

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

            BaseUITab.BaseUITabInstance.Show();
            anyTabOpen = true;
            SettingsUITab.SettingsTabInstance.Show();
            SettingsTabOpen = true;
        }
        else if (anyTabOpen && !SettingsTabOpen)
        {
            HideAllMenuTabs();

            SettingsUITab.SettingsTabInstance.Show();
            SettingsTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.BaseUITabInstance.Hide();
            anyTabOpen = false;
            SettingsUITab.SettingsTabInstance.Hide();
            SettingsTabOpen = false;
        }
    }

    private void GameInput_OnSkillsTabOpened(object sender, System.EventArgs e) {
        if (!SkillsTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.BaseUITabInstance.Show();
            anyTabOpen = true;
            SkillsTabUI.SkillsTabInstance.Show();
            SkillsTabOpen = true;
        }
        else if (anyTabOpen && !SkillsTabOpen)
        {
            HideAllMenuTabs();

            SkillsTabUI.SkillsTabInstance.Show();
            SkillsTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.BaseUITabInstance.Hide();
            anyTabOpen = false;
            SkillsTabUI.SkillsTabInstance.Hide();
            SkillsTabOpen = false;
        }
    }

    private void GameInput_OnQuestsTabOpened(object sender, System.EventArgs e) {
        if (!QuestsTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.BaseUITabInstance.Show();
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

            BaseUITab.BaseUITabInstance.Hide();
            anyTabOpen = false;
            QuestsTabUI.QuestsInstance.Hide();
            QuestsTabOpen = false;
        }
    }

    private void GameInput_OnMapTabOpened(object sender, System.EventArgs e) {
        if (!MapTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.BaseUITabInstance.Show();
            anyTabOpen = true;
            MapTabUI.MapTabInstance.Show();
            MapTabOpen = true;
        }
        else if (anyTabOpen && !MapTabOpen)
        {
            HideAllMenuTabs();

            MapTabUI.MapTabInstance.Show();
            MapTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.BaseUITabInstance.Hide();
            anyTabOpen = false;
            MapTabUI.MapTabInstance.Hide();
            MapTabOpen = false;
        }
    }

    private void GameInput_OnInventoryTabOpened(object sender, System.EventArgs e) {
        if (!InventoryTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.BaseUITabInstance.Show();
            anyTabOpen = true;
            InventoryTabUI.InventoryTabInstance.Show();
            InventoryTabOpen = true;
        }
        else if (anyTabOpen && !InventoryTabOpen)
        {
            HideAllMenuTabs();

            InventoryTabUI.InventoryTabInstance.Show();
            InventoryTabOpen = true;
        }
        else
        {
            HudUI.Instance.Show();

            BaseUITab.BaseUITabInstance.Hide();
            anyTabOpen = false;
            InventoryTabUI.InventoryTabInstance.Hide();
            InventoryTabOpen = false;
        }
    }

    private void GameInput_OnCharacterTabOpened(object sender, System.EventArgs e) {
        if (!CharacterTabOpen && !anyTabOpen)
        {
            HudUI.Instance.Hide();

            BaseUITab.BaseUITabInstance.Show();
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

            BaseUITab.BaseUITabInstance.Hide();
            anyTabOpen = false;
            StatsTabUI.StatInstance.Hide();
            CharacterTabOpen = false;

        }
    }


    private void GameInput_OnExperienceTest(object sender, System.EventArgs e) => ExperienceTest.Instance.Show();

    private void HideAllMenuTabs() {
        InventoryTabUI.InventoryTabInstance.Hide();
        InventoryTabOpen = false;
        
        MapTabUI.MapTabInstance.Hide();
        MapTabOpen = false;
        
        SkillsTabUI.SkillsTabInstance.Hide();
        SkillsTabOpen = false;

        SettingsUITab.SettingsTabInstance.Hide();
        SettingsTabOpen = false;

        StatsTabUI.StatInstance.Hide();
        CharacterTabOpen = false;

        QuestsTabUI.QuestsInstance.Hide();
        QuestsTabOpen = false;
    }

}
