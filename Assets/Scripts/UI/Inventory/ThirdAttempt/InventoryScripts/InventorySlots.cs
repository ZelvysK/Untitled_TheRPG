using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlots
{
    //REFERENCES
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    //FIELDS
    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    //Ctor to create occupied Inventory Slot
    public InventorySlots(InventoryItemData source, int amount) {
        itemData = source;
        stackSize = amount;
    }

    //Ctor to create an empty Inventory Slot
    public InventorySlots() {
        ClearSlot();
    }

    //Clear a slot
    public void ClearSlot() {
        itemData = null;
        stackSize = -1;
    }

    //Update Inventory Slot
    public void UpdateInventorySlot(InventoryItemData data, int amount) {
        itemData = data;
        stackSize = amount;
    }

    //Check if there can be more Items in the same stack
    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining) {
        amountRemaining = ItemData.MaxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);
    }
    public bool RoomLeftInStack(int amountToAdd) => stackSize + amountToAdd <= itemData.MaxStackSize;

    //Add and Remove from stack
    public void AddToStack(int amount) => stackSize += amount;
    public void RemoveFromStack(int amount) => stackSize -= amount;

    //Assign an Item to a Slot
    public void AssignItem(InventorySlots invSlot) {
        if (itemData == invSlot.ItemData) AddToStack(invSlot.stackSize);
        else
        {
            itemData = invSlot.ItemData;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
    }
    
    //Split stack in half
    public bool SplitStack(out InventorySlots splitStack) {
        if (stackSize <= 1)
        {
            splitStack = null;
            return false;
        }
        int halfStack = Mathf.RoundToInt(stackSize / 2);
        RemoveFromStack(halfStack);

        splitStack = new InventorySlots(itemData, halfStack);
        return true;
    }
}
