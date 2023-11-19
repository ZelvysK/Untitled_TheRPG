using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform InteractionPoint;
    public LayerMask InteractionLayer;
    public float InteractionRadius = 1f;
    public bool IsInteracting {  get; private set; }

    private void Update() {
        var colliders = Physics.OverlapSphere(InteractionPoint.position, InteractionRadius, InteractionLayer);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                var interactable = colliders[i].GetComponent<IInteractable>();

                if (interactable != null) StartInteraction(interactable);
            }
        }
    }

    private void StartInteraction(IInteractable interactable) {
        interactable.Interact(this, out bool interactSuccessful);
        IsInteracting = true;
    }

    private void EndInteraction() {
        IsInteracting = false;
    }

}
