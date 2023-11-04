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




    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        //Testing tabs
        playerInputActions.UIElements.Enable();
        playerInputActions.UIElements.ExperienceTest.performed += ExperienceTest_performed;

        //Main tab control events
        playerInputActions.UIElements.CharacterTab.performed += CharacterTab_performed;
        playerInputActions.UIElements.InventoryTab.performed += InventoryTab_performed;
        playerInputActions.UIElements.MapTab.performed += MapTab_performed;
        playerInputActions.UIElements.QuestsTab.performed += QuestsTab_performed;
        playerInputActions.UIElements.SettingsTab.performed += SettingsTab_performed;
        playerInputActions.UIElements.SkillsTab.performed += SkillsTab_performed;
    }

    //Main UI
    private void SkillsTab_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnSkillsTabOpened?.Invoke(this, EventArgs.Empty);
    }

    private void SettingsTab_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnSettingsTabOpened?.Invoke(this, EventArgs.Empty);
    }

    private void QuestsTab_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnQuestsTabOpened?.Invoke(this, EventArgs.Empty);
    }

    private void MapTab_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnMapTabOpened?.Invoke(this, EventArgs.Empty);
    }

    private void InventoryTab_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInventoryTabOpened?.Invoke(this, EventArgs.Empty);
    }

    private void CharacterTab_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnCharacterTabOpened?.Invoke(this, EventArgs.Empty);
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
}
