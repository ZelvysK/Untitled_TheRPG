using UnityEngine;

// This is for main UI control
public class _ManagerUIExample : MonoBehaviour
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

        anyTabOpen = false;

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

            anyTabOpen = true;
            SettingsTabOpen = true;
        }
        else if (anyTabOpen && !SettingsTabOpen)
        {
            HideAllMenuTabs();

            SettingsTabOpen = true;
        }
        else
        {

            anyTabOpen = false;
            SettingsTabOpen = false;
        }
    }
    private void GameInput_OnSkillsTabOpened(object sender, System.EventArgs e) {
        if (!SkillsTabOpen && !anyTabOpen)
        {

            anyTabOpen = true;
            SkillsTabOpen = true;
        }
        else if (anyTabOpen && !SkillsTabOpen)
        {
            HideAllMenuTabs();

            SkillsTabOpen = true;
        }
        else
        {

            anyTabOpen = false;
            SkillsTabOpen = false;
        }
    }
    private void GameInput_OnQuestsTabOpened(object sender, System.EventArgs e) {
        if (!QuestsTabOpen && !anyTabOpen)
        {

            anyTabOpen = true;
            QuestsTabOpen = true;
        }
        else if (anyTabOpen && !QuestsTabOpen)
        {
            HideAllMenuTabs();

            QuestsTabOpen = true;
        }
        else
        {

            anyTabOpen = false;
            QuestsTabOpen = false;
        }
    }
    private void GameInput_OnMapTabOpened(object sender, System.EventArgs e) {
        if (!MapTabOpen && !anyTabOpen)
        {

            anyTabOpen = true;
            MapTabOpen = true;
        }
        else if (anyTabOpen && !MapTabOpen)
        {
            HideAllMenuTabs();

            MapTabOpen = true;
        }
        else
        {

            anyTabOpen = false;
            MapTabOpen = false;
        }
    }
    private void GameInput_OnInventoryTabOpened(object sender, System.EventArgs e) {
        if (!InventoryTabOpen && !anyTabOpen)
        {

            anyTabOpen = true;
            InventoryTabOpen = true;
        }
        else if (anyTabOpen && !InventoryTabOpen)
        {
            HideAllMenuTabs();

            InventoryTabOpen = true;
        }
        else
        {

            anyTabOpen = false;
            InventoryTabOpen = false;
        }
    }
    private void GameInput_OnCharacterTabOpened(object sender, System.EventArgs e) {
        if (!CharacterTabOpen && !anyTabOpen)
        {

            anyTabOpen = true;
            CharacterTabOpen = true;
        }
        else if (anyTabOpen && !CharacterTabOpen)
        {
            HideAllMenuTabs();

            //Show CharacterTab
            CharacterTabOpen = true;
        }
        else
        {

            anyTabOpen = false;
            CharacterTabOpen = false;

        }
    }

    private void GameInput_OnExperienceTest(object sender, System.EventArgs e) => ExperienceTest.Instance.Show();

    private void HideAllMenuTabs() {
        InventoryTabOpen = false;
        
        MapTabOpen = false;
        
        SkillsTabOpen = false;

        SettingsTabOpen = false;

        CharacterTabOpen = false;

        //Debug.Log(QuestsTabUI.QuestsInstance);
        QuestsTabOpen = false;
    }

}
