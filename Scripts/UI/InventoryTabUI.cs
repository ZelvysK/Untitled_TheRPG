using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO:
// 1. Set up Inventory tab UI GameObject
// 2. Add ItemSO
// 3. Display items

public class InventoryTabUI : BaseUITab
{
    public static InventoryTabUI InventoryTabInstance { get; private set; }

    private void Awake() {
        InventoryTabInstance = this;
    }

}
