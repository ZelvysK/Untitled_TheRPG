using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplay : InventoryDisplay
{
    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlots_UI[] slots;

    protected override void Start() {
        base.Start();

        if (inventoryHolder != null)
        {
            inventorySystem = inventoryHolder.InventorySystem;
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        else
        {
            Debug.Log($"No inventory system assigned to {this.gameObject}");
        }

        AssignSlots(inventorySystem);
    }
    public override void AssignSlots(InventorySystem invToDisplay) {
        slotDictionary = new Dictionary<InventorySlots_UI, InventorySlots>();

        if (slots.Length != inventorySystem.InventorySize) Debug.Log($"Inventory slots out of sync on {this.gameObject}");

        for (int i = 0; i < inventorySystem.InventorySize; i++) 
        {
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init(inventorySystem.InventorySlots[i]);
        }
    }
}
