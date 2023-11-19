using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryItem
{
    public ItemSO itemSO;
    public int stackSize;

    public InventoryItem(ItemSO item) {
        itemSO = item;
        AddToStack();
    }

    public void AddToStack() => stackSize++;
    public void RemoveFromStack() => stackSize--;
}
