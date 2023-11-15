using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static event Action<List<InventoryItem>> OnInventoryChanged;

    public List<InventoryItem> inventoryList = new List<InventoryItem>();
    private Dictionary<ItemSO, InventoryItem> itemDictionary = new Dictionary<ItemSO, InventoryItem>();

    public void AddItem(ItemSO itemSO) {
        if (itemDictionary.TryGetValue(itemSO, out InventoryItem item))
        {
            item.AddToStack();
            OnInventoryChanged?.Invoke(inventoryList);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemSO);
            inventoryList.Add(newItem);
            itemDictionary.Add(itemSO, newItem);
            OnInventoryChanged?.Invoke(inventoryList);
        }
    }

    public void RemoveItem(ItemSO itemSO) {
        if (itemDictionary.TryGetValue(itemSO, out InventoryItem item))
        {
            item.RemoveFromStack();
            if (item.stackSize ==0)
            {
                inventoryList.Remove(item);
                itemDictionary.Remove(itemSO);
            }
            OnInventoryChanged?.Invoke(inventoryList);
        }
    }
}
