using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlots : ISerializationCallbackReceiver
{
    //REFERENCES
    [NonSerialized] private InventoryItemData itemData;
    [SerializeField] private int _itemID = -1;
    [SerializeField] private int stackSize;

    //FIELDS
    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    //Ctor to create occupied Inventory Slot
    public InventorySlots(InventoryItemData source, int amount) {
        itemData = source;
        _itemID = itemData.ID;
        stackSize = amount;
    }

    //Ctor to create an empty Inventory Slot
    public InventorySlots() {
        ClearSlot();
    }

    //Clear a slot
    public void ClearSlot() {
        itemData = null;
        _itemID = -1;
        stackSize = -1;
    }

    //Update Inventory Slot
    public void UpdateInventorySlot(InventoryItemData data, int amount) {
        itemData = data;
        _itemID = itemData.ID;
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
            _itemID = itemData.ID;
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

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize() {
        if (_itemID == -1) return;

        //Can load this on GameManager, so we don't have to always do this
        var db = Resources.Load<ItemDb>("ItemDatabase");
        itemData = db.GetItem(_itemID);
    }
}
