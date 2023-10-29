using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnExperienceTest;

    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.UIElements.Enable();
        playerInputActions.UIElements.ExperienceTest.performed += ExperienceTest_performed;
    }

    private void ExperienceTest_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnExperienceTest?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        
        return inputVector;
    }
}
