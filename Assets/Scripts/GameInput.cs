using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    //Testing UI events
    public event EventHandler OnExperienceTestOpened;

    //Main UI events
    public event EventHandler OnCharacterTabOpened;
    public event EventHandler OnInventoryTabOpened;
    public event EventHandler OnMapTabOpened;
    public event EventHandler OnQuestsTabOpened;
    public event EventHandler OnSkillsTabOpened;
    public event EventHandler OnSettingsTabOpened;

    //Player Input
    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        //Testing tabs
        playerInputActions.UIElements.Enable();
        playerInputActions.UIElements.ExperienceTest.performed += ExperienceTest_performed;

        //Main tab control events
        playerInputActions.UIElements.CharacterTab.performed += _ => OnCharacterTabOpened?.Invoke(this, EventArgs.Empty);
        playerInputActions.UIElements.InventoryTab.performed += _ => OnInventoryTabOpened?.Invoke(this, EventArgs.Empty);
        playerInputActions.UIElements.MapTab.performed += _ => OnMapTabOpened?.Invoke(this, EventArgs.Empty);
        playerInputActions.UIElements.QuestsTab.performed += _ => OnQuestsTabOpened?.Invoke(this, EventArgs.Empty);
        playerInputActions.UIElements.SettingsTab.performed += _ => OnSettingsTabOpened?.Invoke(this, EventArgs.Empty);
        playerInputActions.UIElements.SkillsTab.performed += _ => OnSkillsTabOpened?.Invoke(this, EventArgs.Empty);
    }

    //---------------------------------------------------------------------------------------------------//

    //Testing UI
    private void ExperienceTest_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnExperienceTestOpened?.Invoke(this, EventArgs.Empty);
    }
    //---------------------------------------------------------------------------------------------------//

    public Vector2 GetMovementNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    public bool GetJumpInput() => playerInputActions.Player.Jump.IsPressed();

    public bool GetSprintInput() => playerInputActions.Player.Sprint.IsPressed();

    public string GetMovementBindingText(MovementBinding binding) {
        switch (binding)
        {
            default:
            case MovementBinding.MoveForward:
                return playerInputActions.Player.Move.bindings[1].ToDisplayString();
            case MovementBinding.MoveBack:
                return playerInputActions.Player.Move.bindings[2].ToDisplayString();
            case MovementBinding.MoveLeft:
                return playerInputActions.Player.Move.bindings[3].ToDisplayString();
            case MovementBinding.MoveRight:
                return playerInputActions.Player.Move.bindings[4].ToDisplayString();
            case MovementBinding.Jump:
                return playerInputActions.Player.Jump.bindings[0].ToDisplayString();
            case MovementBinding.Sprint:
                return playerInputActions.Player.Sprint.bindings[0].ToDisplayString();
        }
    }
    public string GetTabBindingText(TabBinding binding) {
        switch (binding)
        {
            default:
            case TabBinding.CharacterTab:
                return playerInputActions.UIElements.CharacterTab.bindings[0].ToDisplayString();
            case TabBinding.InventoryTab:
                return playerInputActions.UIElements.InventoryTab.bindings[0].ToDisplayString();
            case TabBinding.MapTab:
                return playerInputActions.UIElements.MapTab.bindings[0].ToDisplayString();
            case TabBinding.QuestsTab:
                return playerInputActions.UIElements.QuestsTab.bindings[0].ToDisplayString();
            case TabBinding.SkillsTab:
                return playerInputActions.UIElements.SkillsTab.bindings[0]. ToDisplayString();
            case TabBinding.SettingsTab:
                return playerInputActions.UIElements.SettingsTab.bindings[0].ToDisplayString();
        }
    }
    public enum MovementBinding
    {
        MoveForward,
        MoveBack,
        MoveLeft,
        MoveRight,
        Jump,
        Sprint,
    }
    public enum TabBinding
    {
        CharacterTab,
        InventoryTab,
        SkillsTab,
        SettingsTab,
        QuestsTab,
        MapTab,
    }

    public bool InventoryTriggered() => playerInputActions.UIElements.InventoryTab.triggered;
}
