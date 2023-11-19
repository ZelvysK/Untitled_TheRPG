using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{
    //REFERENCES
    public DynamicInventoryDisplay inventoryPanel;

    private void Awake() {
        inventoryPanel.gameObject.SetActive(false);
    }
    private void OnEnable() => InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;

    private void OnDisable() => InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;

    private void Update() {
        if (inventoryPanel.gameObject.activeInHierarchy &&
            Keyboard.current.escapeKey.wasPressedThisFrame) inventoryPanel.gameObject.SetActive(false);
    }
    private void DisplayInventory(InventorySystem invToDisplay) {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.RefreshDynamicInventory(invToDisplay);
    }
}
