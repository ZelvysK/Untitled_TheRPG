using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplay : InventoryDisplay
{
    //REFERENCES
    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlots_UI[] slots;


    private void OnEnable() {
        PlayerInventoryHolder.OnPlayerInventoryChanged += RefreshStaticDisplay;
    }
    private void OnDisable() {
        PlayerInventoryHolder.OnPlayerInventoryChanged -= RefreshStaticDisplay;
    }
    private void RefreshStaticDisplay() {
        if (inventoryHolder != null)
        {
            inventorySystem = inventoryHolder.PrimaryInventorySystem;
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        else
        {
            Debug.Log($"No inventory system assigned to {this.gameObject}");
        }

        AssignSlots(inventorySystem, 0);
    }

    protected override void Start() {
        base.Start();

        RefreshStaticDisplay();
    }
    public override void AssignSlots(InventorySystem invToDisplay, int offset) {
        slotDictionary = new Dictionary<InventorySlots_UI, InventorySlots>();

        for (int i = 0; i < inventoryHolder.Offset; i++)
        {
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init(inventorySystem.InventorySlots[i]);
        }
    }
}
