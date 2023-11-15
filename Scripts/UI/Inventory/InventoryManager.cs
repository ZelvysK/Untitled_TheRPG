using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private List<InvSlot> inventorySlots = new List<InvSlot>(10);

    private void OnEnable() => Inventory.OnInventoryChanged += DrawInventory;
    private void OnDisable() => Inventory.OnInventoryChanged -= DrawInventory;
    private void ResetInventory() {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InvSlot>(10);
    }
    private void DrawInventory(List<InventoryItem> inventory) {
        ResetInventory();

        for (int i = 0; i < inventorySlots.Capacity; i++)
        {
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }
    private void CreateInventorySlot() {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InvSlot newSlotComponent = newSlot.GetComponent<InvSlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }
}
