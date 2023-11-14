using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemImage;
    Storage storage;
    MouseDrag mouseDrag;

    public void SetupStorage(Storage storage) {
        this.storage = storage;
    }

    public Storage GetStorage() {
        return storage;
    }

    internal void UpdateUI(ItemSO itemSO) {
        if (itemSO == null)
        {
            itemImage.sprite = null;
            return;
        }
        itemImage.sprite = itemSO.itemSprite;
    }

    internal void SetupMouseControl(Storage storage) {
        mouseDrag = gameObject.GetOrAddComponent<MouseDrag>();
        mouseDrag.SetupStorage(storage, this);
    }
}
