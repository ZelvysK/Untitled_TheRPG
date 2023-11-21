using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UniqueID))]
public class ChestInventory : InventoryHolder, IInteractable
{
    //EVENTS
    public UnityAction<IInteractable> OnInteractionComplete { get; set; }

    protected override void Awake() {
        base.Awake();
        SaveLoad.OnLoadGame += LoadInventory;
    }

    private void Start() {
        var chestSaveData = new InventorySaveData(primaryInventorySystem, transform.position, transform.rotation);

        SaveGameManager.data.chestDictionary.Add(GetComponent<UniqueID>().ID, chestSaveData);
    }

    protected override void LoadInventory(SaveData data) {
        if (data.chestDictionary.TryGetValue(GetComponent<UniqueID>().ID, out InventorySaveData chestData))
        {
            this.primaryInventorySystem = chestData.InvSystem;
            this.transform.position = chestData.Position;
            this.transform.rotation = chestData.Rotation;
        }
    }

    public void Interact(Interactor interactor, out bool interactSuccessful) {
        OnDynamicInventoryDisplayRequested?.Invoke(primaryInventorySystem, 0);
        interactSuccessful = true;
    }
    public void EndInteraction() {
        throw new System.NotImplementedException();
    }

}
