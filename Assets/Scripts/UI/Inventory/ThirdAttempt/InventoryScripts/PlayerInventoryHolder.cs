using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInventoryHolder : InventoryHolder
{
    //FIELDS
    [SerializeField] protected int secondaryInventorySize;
    [SerializeField] protected InventorySystem secondaryInventorySystem;
    [SerializeField] protected GameInput gameInput;

    public InventorySystem SecondaryInventorySystem => secondaryInventorySystem;

    public static UnityAction<InventorySystem> OnPlayerBackpackDisplayRequested;

    protected override void Awake() {
        base.Awake();

        secondaryInventorySystem = new InventorySystem(secondaryInventorySize);
    }

    void Update() {
        //if (Keyboard.current.bKey.wasPressedThisFrame) OnPlayerBackpackDisplayRequested?.Invoke(secondaryInventorySystem);
        if (gameInput.InventoryTriggered()) OnPlayerBackpackDisplayRequested?.Invoke(secondaryInventorySystem);
    }

    public bool AddToInventory(InventoryItemData data, int amount) {
        if (primaryInventorySystem.AddToInventory(data, amount)) return true;
        else if (secondaryInventorySystem.AddToInventory(data, amount)) return true;
        return false;
    }
}
