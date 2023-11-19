using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlots
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlots(InventoryItemData source, int amount) {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlots() {
        ClearSlot();
    }

    public void ClearSlot() {
        itemData = null;
        stackSize = -1;
    }

    public void UpdateInventorySlot(InventoryItemData data, int amount) {
        itemData = data;
        stackSize = amount;
    }

    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining) {
        amountRemaining = ItemData.MaxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd) {
        return stackSize + amountToAdd <= itemData.MaxStackSize;
    }

    public void AddToStack(int amount) => stackSize += amount;

    public void RemoveFromStack(int amount) => stackSize -= amount;

    public void AssignItem(InventorySlots invSlot) {
        if (itemData == invSlot.ItemData) AddToStack(invSlot.stackSize);
        else
        {
            itemData = invSlot.ItemData;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
    }

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
