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
}
