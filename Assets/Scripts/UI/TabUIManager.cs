using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabUIManager : MonoBehaviour
{
    //VARIABLES
    private const string CHARACTER_TAB = "CharacterTab";
    private const string INVENTORY_TAB = "InventoryTab";
    private const string MAP_TAB = "MapTab";
    private const string SETTINGS_TAB = "SettingsTab";
    private const string SKILLS_TAB = "SkillsTab";
    private const string QUESTS_TAB = "QuestsTab";

    private static TabUIManager TabUIManagerInstance;

    [SerializeField] private GameInput gameInput;
    [SerializeField] private List<BaseUITab> tabs;

    //Main tab bools
    public bool CharacterTabOpen { get; set; } = false;
    public bool InventoryTabOpen { get; set; } = false;
    public bool MapTabOpen { get; set; } = false;
    public bool QuestsTabOpen { get; set; } = false;
    public bool SkillsTabOpen { get; set; } = false;
    public bool SettingsTabOpen { get; set; } = false;

    //Base tab bool
    private bool anyTabOpen = false;

    //REFERENCES
    [SerializeField] private HudUI hudUI;
    [SerializeField] private BaseUITab baseUI;
    [SerializeField] private TabSwitcherUI tabSwitcherUI;
    //[SerializeField] private List<GameObject> tabObjects;

    //private SkillsTabUI skillsTab;
    //private InventoryTabUI inventoryTab;
    //private CharacterTab characterTab;
    //private MapTabUI mapTab;
    //private QuestsTabUI questsTab;
    //private SettingsUITab settingsTab;

    //Don't think Action works here, because these are KeyPressed events
    //Also don't know what to use as extension for GameObject to add enum
    //Dictionary<TabType, Action> 
    private void Awake() {
        if (TabUIManagerInstance == null)
        {
            TabUIManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        tabSwitcherUI.Hide();
        baseUI.Hide();
        hudUI.Show();

        anyTabOpen = false;
        HideAllTabs();
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
        if (!SettingsTabOpen && !anyTabOpen)
        {
            hudUI.Hide();

            anyTabOpen = true;
            tabSwitcherUI.Show();
            tabSwitcherUI.SelectTabButton(SETTINGS_TAB);

            baseUI.Show();
            SettingsTabOpen = true;
            tabs.Find(t => t.TabName == SETTINGS_TAB).Show();
        }
        else if (anyTabOpen && !SettingsTabOpen)
        {
            HideAllTabs();

            SettingsTabOpen = true;
            tabs.Find(t => t.TabName == SETTINGS_TAB).Show();
            tabSwitcherUI.SelectTabButton(SETTINGS_TAB);
        }
        else
        {
            hudUI.Show();

            anyTabOpen = false;
            tabSwitcherUI.Hide();
            baseUI.Hide();
            SettingsTabOpen = false;
            tabs.Find(t => t.TabName == SETTINGS_TAB).Hide();
        }
    }
    private void GameInput_OnSkillsTabOpened(object sender, EventArgs e) {
        if (!SkillsTabOpen && !anyTabOpen)
        {
            hudUI.Hide();

            anyTabOpen = true;
            tabSwitcherUI.Show();
            tabSwitcherUI.SelectTabButton(SKILLS_TAB);

            baseUI.Show();
            SkillsTabOpen = true;
            tabs.Find(t => t.TabName == SKILLS_TAB).Show();
        }
        else if (anyTabOpen && !SkillsTabOpen)
        {
            HideAllTabs();

            SkillsTabOpen = true;
            tabs.Find(t => t.TabName == SKILLS_TAB).Show();
            tabSwitcherUI.SelectTabButton(SKILLS_TAB);
        }
        else
        {
            hudUI.Show();

            anyTabOpen = false;
            tabSwitcherUI.Hide();
            baseUI.Hide();
            SkillsTabOpen = false;
            tabs.Find(t => t.TabName == SKILLS_TAB).Hide();
        }
    }
    private void GameInput_OnQuestsTabOpened(object sender, EventArgs e) {
        if (!QuestsTabOpen && !anyTabOpen)
        {
            hudUI.Hide();

            anyTabOpen = true;
            tabSwitcherUI.Show();
            tabSwitcherUI.SelectTabButton(QUESTS_TAB);

            baseUI.Show();
            QuestsTabOpen = true;
            tabs.Find(t => t.TabName == QUESTS_TAB).Show();
        }
        else if (anyTabOpen && !QuestsTabOpen)
        {
            HideAllTabs();

            QuestsTabOpen = true;
            tabs.Find(t => t.TabName == QUESTS_TAB).Show();
            tabSwitcherUI.SelectTabButton(QUESTS_TAB);
        }
        else
        {
            hudUI.Show();

            anyTabOpen = false;
            tabSwitcherUI.Hide();
            baseUI.Hide();
            QuestsTabOpen = false;
            tabs.Find(t => t.TabName == QUESTS_TAB).Hide();
        }
    }
    private void GameInput_OnMapTabOpened(object sender, EventArgs e) {
        if (!MapTabOpen && !anyTabOpen)
        {
            hudUI.Hide();

            anyTabOpen = true;
            tabSwitcherUI.Show();
            tabSwitcherUI.SelectTabButton(MAP_TAB);

            baseUI.Show();
            MapTabOpen = true;
            tabs.Find(t => t.TabName == MAP_TAB).Show();
        }
        else if (anyTabOpen && !MapTabOpen)
        {
            HideAllTabs();

            MapTabOpen = true;
            tabs.Find(t => t.TabName == MAP_TAB).Show();
            tabSwitcherUI.SelectTabButton(MAP_TAB);
        }
        else
        {
            hudUI.Show();

            anyTabOpen = false;
            tabSwitcherUI.Hide();
            baseUI.Hide();
            MapTabOpen = false;
            tabs.Find(t => t.TabName == MAP_TAB).Hide();
        }
    }
    private void GameInput_OnInventoryTabOpened(object sender, EventArgs e) {
        if (!InventoryTabOpen && !anyTabOpen)
        {
            hudUI.Hide();

            anyTabOpen = true;
            tabSwitcherUI.Show();
            tabSwitcherUI.SelectTabButton(INVENTORY_TAB);

            baseUI.Show();
            InventoryTabOpen = true;
            tabs.Find(t => t.TabName == INVENTORY_TAB).Show();
        }
        else if (anyTabOpen && !InventoryTabOpen)
        {
            HideAllTabs();

            InventoryTabOpen = true;
            tabs.Find(t => t.TabName == INVENTORY_TAB).Show();
            tabSwitcherUI.SelectTabButton(INVENTORY_TAB);
        }
        else
        {
            hudUI.Show();

            anyTabOpen = false;
            tabSwitcherUI.Hide();
            baseUI.Hide();
            InventoryTabOpen = false;
            tabs.Find(t => t.TabName == INVENTORY_TAB).Hide();
        }
    }
    private void GameInput_OnCharacterTabOpened(object sender, EventArgs e) {
        if (!CharacterTabOpen && !anyTabOpen)
        {
            hudUI.Hide();

            anyTabOpen = true;
            tabSwitcherUI.Show();
            tabSwitcherUI.SelectTabButton(CHARACTER_TAB);

            baseUI.Show();
            CharacterTabOpen = true;
            tabs.Find(t => t.TabName == CHARACTER_TAB).Show();
        }
        else if (!CharacterTabOpen && anyTabOpen)
        {
            HideAllTabs();

            CharacterTabOpen = true;
            tabs.Find(t => t.TabName == CHARACTER_TAB).Show();
            tabSwitcherUI.SelectTabButton(CHARACTER_TAB);
        }
        else
        {
            hudUI.Show();

            anyTabOpen = false;
            tabSwitcherUI.Hide();
            baseUI.Hide();
            CharacterTabOpen = false;
            tabs.Find(t => t.TabName == CHARACTER_TAB).Hide();
        }
    }
    private void GameInput_OnExperienceTest(object sender, EventArgs e) {
        throw new NotImplementedException();
    }

    private void HideAllTabs() {
        foreach (var tab in tabs)
        {
            tab.Hide();
        }
        CharacterTabOpen = false;
        InventoryTabOpen = false;
        SkillsTabOpen = false;
        SettingsTabOpen = false;
        MapTabOpen = false;
        QuestsTabOpen = false;

    }
}

//Extra Methods
//
//public void ShowTab(int tabIndex) {
//    if (tabIndex < tabs.Count)
//    {
//        tabs[tabIndex].Show();
//    }
//}
//public void HideTab(int tabIndex) {
//    if (tabIndex < tabs.Count)
//    {
//        tabs[tabIndex].Hide();
//    }
//}
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
//public void AddTab(BaseUITab tab) => tabs.Add(tab);

//public void ShowTab(string tabName) {
//    BaseUITab tab = tabs.Find(t => t.TabName == tabName);
//    if (tab != null)
//    {
//        tab.Show();
//    }
//}
//public void HideTab(string tabName) {
//    BaseUITab tab = tabs.Find(t => t.TabName == tabName);
//    if (tab != null)
//    {
//        tab.Hide();
//    }
//}
