using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

public class MouseItemData : MonoBehaviour
{
    //FIELDS
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount;
    public InventorySlots AssignedInventorySlot;

    private void Awake() {
        ItemSprite.color = Color.clear;
        ItemCount.text = string.Empty;
    }
    //Make the Mouse Slot follow the Cursor
    private void Update() {
        // TODO: Add controller support
        if (AssignedInventorySlot.ItemData != null)
        {
            transform.position = Mouse.current.position.ReadValue();

            if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObject())
            {
                ClearSlot();
                // TODO: Drop the Item on the ground
            }
        }
    }

    //Assign item to mouse slot
    internal void UpdateMouseSlot(InventorySlots invSlot) {
        AssignedInventorySlot.AssignItem(invSlot);
        ItemSprite.sprite = invSlot.ItemData.Icon;
        ItemCount.text = invSlot.StackSize.ToString();
        ItemSprite.color = Color.white;
    }
    //Clear mouse slot
    public void ClearSlot() {
        AssignedInventorySlot.ClearSlot();
        ItemCount.text = string.Empty;
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
    }

    //Taken for StackOverflow?
    //Check if Mouse.Position is over UI object
    public static bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
