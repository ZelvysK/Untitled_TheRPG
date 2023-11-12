using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// TODO:
// 1. Add buttons to change KeyBingings
// 2. Add Sound & Music settings

public class SettingsUITab : BaseUITab
{
    //REFERENCES
    [SerializeField] private GameInput gameInput;
    
    //Movement KeyBinds
    [SerializeField] private TextMeshProUGUI forwardText;
    [SerializeField] private TextMeshProUGUI backwardText;
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private TextMeshProUGUI rightText;
    [SerializeField] private TextMeshProUGUI sprintText;
    [SerializeField] private TextMeshProUGUI jumpText;
    //Tab KeyBinds
    [SerializeField] private TextMeshProUGUI characterTabText;
    [SerializeField] private TextMeshProUGUI inventoryTabText;
    [SerializeField] private TextMeshProUGUI mapTabText;
    [SerializeField] private TextMeshProUGUI questsTabText;
    [SerializeField] private TextMeshProUGUI skillsTabText;
    [SerializeField] private TextMeshProUGUI settingsTabText;

    private void Awake() {
        SetMovementBindsText();
        SetTabsBindingText();
    }

    private void SetMovementBindsText() {
        if (gameInput != null)
        {
            forwardText.text = gameInput.GetMovementBindingText(GameInput.MovementBinding.MoveForward);
            backwardText.text = gameInput.GetMovementBindingText(GameInput.MovementBinding.MoveForward);
            leftText.text = gameInput.GetMovementBindingText(GameInput.MovementBinding.MoveLeft);
            rightText.text = gameInput.GetMovementBindingText(GameInput.MovementBinding.MoveRight);
            sprintText.text = gameInput.GetMovementBindingText(GameInput.MovementBinding.Sprint);
            jumpText.text = gameInput.GetMovementBindingText(GameInput.MovementBinding.Jump);
        }
    }
    private void SetTabsBindingText() {
        if(gameInput != null)
        {
            characterTabText.text = gameInput.GetTabBindingText(GameInput.TabBinding.CharacterTab);
            inventoryTabText.text = gameInput.GetTabBindingText(GameInput.TabBinding.InventoryTab);
            mapTabText.text = gameInput.GetTabBindingText(GameInput.TabBinding.MapTab);
            questsTabText.text = gameInput.GetTabBindingText(GameInput.TabBinding.QuestsTab);
            skillsTabText.text = gameInput.GetTabBindingText(GameInput.TabBinding.SkillsTab);
            settingsTabText.text = gameInput.GetTabBindingText(GameInput.TabBinding.SettingsTab);

        }
    }
}
