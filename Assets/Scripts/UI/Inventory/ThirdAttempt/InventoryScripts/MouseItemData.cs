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

    private Transform _playerTransform;
    [SerializeField] private float _dropOffset = 3f;

    private void Awake() {
        ItemSprite.color = Color.clear;
        ItemSprite.preserveAspect = true;
        ItemCount.text = string.Empty;

        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (_playerTransform == null)
        {
            Debug.Log("No player found!");
        }
    }
    //Make the Mouse Slot follow the Cursor
    private void Update() {
        // TODO: Add controller support
        if (AssignedInventorySlot.ItemData != null)
        {
            transform.position = Mouse.current.position.ReadValue();

            if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObject())
            {
                if (AssignedInventorySlot.ItemData.ItemPrefab != null)
                    Instantiate(AssignedInventorySlot.ItemData.ItemPrefab, _playerTransform.position + _playerTransform.forward * _dropOffset, Quaternion.identity);

                if (AssignedInventorySlot.StackSize > 1)
                {
                    AssignedInventorySlot.AddToStack(-1);
                    UpdateMouseSlot();
                }
                else ClearSlot();
            }
        }
    }

    //Assign item to mouse slot
    public void UpdateMouseSlot(InventorySlots invSlot) {
        AssignedInventorySlot.AssignItem(invSlot);
        UpdateMouseSlot();
    }

    public void UpdateMouseSlot() {
        ItemSprite.sprite = AssignedInventorySlot.ItemData.Icon;
        ItemCount.text = AssignedInventorySlot.StackSize.ToString();
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
