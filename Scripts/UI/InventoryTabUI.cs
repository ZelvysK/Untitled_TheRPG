using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO:
// 1. Set up Inventory tab UI GameObject
// 2. Add ItemSO
// 3. Display items

public class InventoryUI : BaseUITab
{
    public static InventoryUI InventoryTabInstance { get; private set; }

    private void Awake() {
        InventoryTabInstance = this;
    }

}
