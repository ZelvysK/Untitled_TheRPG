using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _ManagerUI : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    // Seperate script for each UI element to show/hide
    // This is for main control

    //Main Tabs
    public bool characterTabOpen { get; set; }
    public bool inventoryTabOpen { get; set; }
    public bool mapTabOpen { get; set; }
    public bool questsTabOpen { get; set; }
    public bool skillsTabOpen { get; set; }
    public bool settingsTabOpen { get; set; }


    //Base for all tabs
    private bool anyTabOpen;

    private void Awake() {
        HudUI.HudInstance.Show();

        anyTabOpen = false;
        BaseUITab.Instance.Hide();

        characterTabOpen = false;
        StatsTabUI.StatInstance.Hide();
        //Hide Others
        inventoryTabOpen = false;
        mapTabOpen = false;
        questsTabOpen = false;
        skillsTabOpen = false;
        settingsTabOpen = false;

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
        if (!settingsTabOpen && !anyTabOpen)
        {
            HudUI.HudInstance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            //StatsTabUI.Instance.ShowStats();
            settingsTabOpen = true;
        }
        else if (anyTabOpen && !settingsTabOpen)
        {
            //Hide other tabs
            StatsTabUI.StatInstance.Hide();
            characterTabOpen = false;
            inventoryTabOpen = false;
            questsTabOpen = false;
            skillsTabOpen = false;
            mapTabOpen = false;
            //Show SettingsTab
            settingsTabOpen = true;
        }
        else
        {
            HudUI.HudInstance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            //StatsTabUI.Instance.HideStats();
            settingsTabOpen = false;
        }
    }

    private void GameInput_OnSkillsTabOpened(object sender, System.EventArgs e) {
        if (!skillsTabOpen && !anyTabOpen)
        {
            HudUI.HudInstance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            //StatsTabUI.Instance.ShowStats();
            skillsTabOpen = true;
        }
        else if (anyTabOpen && !skillsTabOpen)
        {
            //Hide other tabs
            StatsTabUI.StatInstance.Hide();
            characterTabOpen = false;
            inventoryTabOpen = false;
            settingsTabOpen = false;
            mapTabOpen = false;
            questsTabOpen = false;
            //Show SkillsTab
            skillsTabOpen = true;
        }
        else
        {
            HudUI.HudInstance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            //StatsTabUI.Instance.HideStats();
            skillsTabOpen = false;
        }
    }

    private void GameInput_OnQuestsTabOpened(object sender, System.EventArgs e) {
        if (!questsTabOpen && !anyTabOpen)
        {
            HudUI.HudInstance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            //StatsTabUI.Instance.ShowStats();
            questsTabOpen = true;
        }
        else if (anyTabOpen && !questsTabOpen)
        {
            //Hide other tabs
            StatsTabUI.StatInstance.Hide();
            characterTabOpen = false;
            inventoryTabOpen = false;
            mapTabOpen = false;
            settingsTabOpen = false;
            skillsTabOpen = false;
            //Show QuestsTab
            questsTabOpen = true;
        }
        else
        {
            HudUI.HudInstance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            //StatsTabUI.Instance.HideStats();
            questsTabOpen = false;
        }
    }

    private void GameInput_OnMapTabOpened(object sender, System.EventArgs e) {
        if (!mapTabOpen && !anyTabOpen)
        {
            HudUI.HudInstance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            //StatsTabUI.Instance.ShowStats();
            mapTabOpen = true;
        }
        else if (anyTabOpen && !mapTabOpen)
        {
            //Hide other tabs
            StatsTabUI.StatInstance.Hide();
            characterTabOpen = false;
            inventoryTabOpen = false;
            settingsTabOpen = false;
            questsTabOpen = false;
            skillsTabOpen = false;
            //Show MapTab
            mapTabOpen = true;
        }
        else
        {
            HudUI.HudInstance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            //StatsTabUI.Instance.HideStats();
            mapTabOpen = false;
        }
    }

    private void GameInput_OnInventoryTabOpened(object sender, System.EventArgs e) {
        if (!inventoryTabOpen && !anyTabOpen)
        {
            HudUI.HudInstance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            //StatsTabUI.Instance.ShowStats();
            inventoryTabOpen = true;
        }
        else if (anyTabOpen && !inventoryTabOpen)
        {
            //Hide other tabs
            StatsTabUI.StatInstance.Hide();
            characterTabOpen = false;

            settingsTabOpen = false;
            mapTabOpen = false;
            questsTabOpen = false;
            skillsTabOpen = false;
            //Show InventoryTab
            inventoryTabOpen = true;
        }
        else
        {
            HudUI.HudInstance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            //StatsTabUI.Instance.HideStats();
            inventoryTabOpen = false;
        }
    }

    private void GameInput_OnCharacterTabOpened(object sender, System.EventArgs e) {
        if (!characterTabOpen && !anyTabOpen)
        {
            HudUI.HudInstance.Hide();

            BaseUITab.Instance.Show();
            anyTabOpen = true;
            StatsTabUI.StatInstance.Show();
            characterTabOpen = true;
        }
        else if (anyTabOpen && !characterTabOpen)
        {
            //Hide other tabs
            inventoryTabOpen = false;
            settingsTabOpen = false;
            mapTabOpen = false;
            questsTabOpen = false;
            skillsTabOpen = false;
            //Show CharacterTab
            StatsTabUI.StatInstance.Show();
            characterTabOpen = true;
        }
        else
        {
            HudUI.HudInstance.Show();

            BaseUITab.Instance.Hide();
            anyTabOpen = false;
            StatsTabUI.StatInstance.Hide();
            characterTabOpen = false;

        }
    }


    private void GameInput_OnExperienceTest(object sender, System.EventArgs e) {
        ExperienceTest.Instance.Show();
    }

}
