using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabUIManager : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;

    //Main tab bools
    public bool CharacterTabOpen { get; set; }
    public bool InventoryTabOpen { get; set; }
    public bool MapTabOpen { get; set; }
    public bool QuestsTabOpen { get; set; }
    public bool SkillsTabOpen { get; set; }
    public bool SettingsTabOpen { get; set; }

    //Base tab bool
    private bool anyTabOpen;

    private List<BaseUITab> tabs = new List<BaseUITab>();

    //Don't think Action works here, because these are KeyPressed events
    //Also don't know what to use as extension for GameObject to add enum
    //Dictionary<TabType, Action> 
    private void Awake() {
        anyTabOpen = false;
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

    private void GameInput_OnSettingsTabOpened(object sender, EventArgs e) {
        throw new NotImplementedException();
    }
    private void GameInput_OnSkillsTabOpened(object sender, EventArgs e) {
        throw new NotImplementedException();
    }
    private void GameInput_OnQuestsTabOpened(object sender, EventArgs e) {
        throw new NotImplementedException();
    }
    private void GameInput_OnMapTabOpened(object sender, EventArgs e) {
        throw new NotImplementedException();
    }
    private void GameInput_OnInventoryTabOpened(object sender, EventArgs e) {
        throw new NotImplementedException();
    }
    private void GameInput_OnCharacterTabOpened(object sender, EventArgs e) {
        throw new NotImplementedException();
    }
    private void GameInput_OnExperienceTest(object sender, EventArgs e) {
        throw new NotImplementedException();
    }

    public void AddTab(BaseUITab tab) => tabs.Add(tab);
    public void ShowTab(int tabIndex) {
        if (tabIndex < tabs.Count)
        {
            tabs[tabIndex].Show();
        }
    }
    public void HideTab(int tabIndex) {
        if (tabIndex < tabs.Count)
        {
            tabs[tabIndex].Hide();
        }
    }

    //public enum TabType
    //{
    //    Base,
    //    Character,
    //    Inventory,
    //    Map,
    //    Quests,
    //    Skills,
    //    Settings,
    //}
}
