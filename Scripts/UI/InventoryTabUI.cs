using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO:
// 1. Set up Inventory tab UI GameObject
// 2. Add ItemSO
// 3. Display items
// 
// Inventory Has 112 slots
// Figure out how to show items:
// Show empty then add ImageObject?
// Show Blank ImageObject for empty then replace with ItemObject?
// Dictionary, List?

public class InventoryTabUI : BaseUITab
{
    public static InventoryTabUI InventoryTabInstance { get; private set; }

    private void Awake() {
        InventoryTabInstance = this;
    }

}
