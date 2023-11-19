using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    //REFERENCES
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem inventorySystem;

    //FIELDS
    public InventorySystem InventorySystem => inventorySystem;

    //EVENTS
    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    private void Awake() {
        inventorySystem = new InventorySystem(inventorySize);
    }
}
