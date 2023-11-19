using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    //REFERENCES
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem primaryInventorySystem;

    //FIELDS
    public InventorySystem PrimaryInventorySystem => primaryInventorySystem;

    //EVENTS
    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    protected virtual void Awake() {
        primaryInventorySystem = new InventorySystem(inventorySize);
    }
}
