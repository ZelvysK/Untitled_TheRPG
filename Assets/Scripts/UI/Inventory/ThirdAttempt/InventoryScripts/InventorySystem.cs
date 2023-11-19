using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    //REFERENCES
    [SerializeField] private List<InventorySlots> inventorySlots;

    //FIELDS
    public List<InventorySlots> InventorySlots => inventorySlots;
    public int InventorySize => inventorySlots.Count;

    //EVENTS
    public UnityAction<InventorySlots> OnInventorySlotChanged;

    //Ctor to create the required inventory
    public InventorySystem(int size) {
        inventorySlots = new List<InventorySlots>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlots());
        }
    }
    //Add an Item to Inventory
    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd) {
        //Check if item exists in Inventory
        if (ContainsItem(itemToAdd, out List<InventorySlots> invSlot))
        {
            foreach (var slot in invSlot)
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }
        //Gets the first available slot
        if (HasFreeSlot(out InventorySlots freeSlot))
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }
        //If nothing passes - don't pick up Item
        return false;
    }
    //Checks if the Inventory Slot contains an Item
    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlots> invSlot) {
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();

        return invSlot == null ? false : true;
    }
    //Check it there are empty InventorySlots
    public bool HasFreeSlot(out InventorySlots freeSlot) {

        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
