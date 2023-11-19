using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{
    //REFERENCES
    public DynamicInventoryDisplay chestPanel;
    public DynamicInventoryDisplay playerBackpackPanel;

    private void Awake() {
        chestPanel.gameObject.SetActive(false);
        playerBackpackPanel.gameObject.SetActive(false);
    }
    private void OnEnable() {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackDisplayRequested += DisplayPlayerBakcpack;
    }

    private void OnDisable() {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackDisplayRequested -= DisplayPlayerBakcpack;
    }

    private void Update() {
        if (chestPanel.gameObject.activeInHierarchy &&
            Keyboard.current.escapeKey.wasPressedThisFrame) chestPanel.gameObject.SetActive(false);

        if (playerBackpackPanel.gameObject.activeInHierarchy &&
            Keyboard.current.escapeKey.wasPressedThisFrame) playerBackpackPanel.gameObject.SetActive(false);
    }
    private void DisplayInventory(InventorySystem invToDisplay) {
        chestPanel.gameObject.SetActive(true);
        chestPanel.RefreshDynamicInventory(invToDisplay);
    }
    private void DisplayPlayerBakcpack(InventorySystem invToDisplay) {
        playerBackpackPanel.gameObject.SetActive(true);
        playerBackpackPanel.RefreshDynamicInventory(invToDisplay);
    }
}
