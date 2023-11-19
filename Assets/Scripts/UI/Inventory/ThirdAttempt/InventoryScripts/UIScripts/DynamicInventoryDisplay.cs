using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicInventoryDisplay : InventoryDisplay
{
    //REFERENCES
    [SerializeField] protected InventorySlots_UI slotPrefab;

    protected override void Start() {
        base.Start();
    }
    
    public void RefreshDynamicInventory(InventorySystem invToDisplay) {
        ClearSlots();
        inventorySystem = invToDisplay;
        if(inventorySystem!= null) inventorySystem.OnInventorySlotChanged += UpdateSlot;
        AssignSlots(invToDisplay);
    }
    public override void AssignSlots(InventorySystem invToDisplay) {
        slotDictionary = new Dictionary<InventorySlots_UI, InventorySlots>();

        if (invToDisplay == null) return;

        for (int i = 0; i < invToDisplay.InventorySize; i++)
        {
            var uiSlot = Instantiate(slotPrefab, transform);
            slotDictionary.Add(uiSlot, invToDisplay.InventorySlots[i]);
            uiSlot.Init(invToDisplay.InventorySlots[i]);
            uiSlot.UpdateUISlot();
        }
    }

    //Clear Inventory Slots (More effective is Object Pooling)
    private void ClearSlots() {
        foreach (var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
        }

        if (slotDictionary != null) slotDictionary.Clear();
    }

    private void OnDisable() {
        if(inventorySystem!= null) inventorySystem.OnInventorySlotChanged -= UpdateSlot;

    }
}
