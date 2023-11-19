using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    //REFERENCES
    [SerializeField] MouseItemData mouseInventoryItem;
    protected InventorySystem inventorySystem;

    //FIELDS
    protected Dictionary<InventorySlots_UI, InventorySlots> slotDictionary;
    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlots_UI, InventorySlots> SlotDictionary => slotDictionary;

    protected virtual void Start() {
    }
    public abstract void AssignSlots(InventorySystem invToDisplay);
    //Update inventory slot
    protected virtual void UpdateSlot(InventorySlots updatedSlot) {
        foreach (var slot in slotDictionary)
        {
            if (slot.Value == updatedSlot) //Slot value
            {
                slot.Key.UpdateUISlot(updatedSlot); //Slot key
            }
        }
    }
    //Logic to move/split items
    public void SlotClicked(InventorySlots_UI clickedUISlot) {
        bool isShiftPressed = Keyboard.current.leftShiftKey.isPressed;
        //Clicked slot has an Item - Mouse doesn't => Pick-Up item
        if (clickedUISlot.AssignedInventorySlot.ItemData != null &&
            mouseInventoryItem.AssignedInventorySlot.ItemData == null)
        {
            //If player holdig shift Split the stack
            if (isShiftPressed && clickedUISlot.AssignedInventorySlot.SplitStack(out InventorySlots halfStackSlot)) //Split stack
            {
                mouseInventoryItem.UpdateMouseSlot(halfStackSlot);
                clickedUISlot.UpdateUISlot();
                return;
            }
            else //Pick up Item
            {
                mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
                clickedUISlot.ClearSlot();
                return;
            }

        }
        //Clicked slot doesn't have an Item - Mouse does = Place mouse Item to slot
        if (clickedUISlot.AssignedInventorySlot.ItemData == null
            && mouseInventoryItem.AssignedInventorySlot.ItemData != null)
        {
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
            return;
        }
        //Both slots have items - decide what to do...
        if (clickedUISlot.AssignedInventorySlot.ItemData != null &&
            mouseInventoryItem.AssignedInventorySlot.ItemData != null)
        {
            var isSameItem = clickedUISlot.AssignedInventorySlot.ItemData == mouseInventoryItem.AssignedInventorySlot.ItemData;
            //Are both the same? Combine if possible
            if (isSameItem &&
                clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize))
            {
                clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
                clickedUISlot.UpdateUISlot();

                mouseInventoryItem.ClearSlot();
                return;
            }
            else if (isSameItem &&
                !clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize, out int leftInStack))
            {
                if (leftInStack < 1) SwapSlots(clickedUISlot); //Stack is full, Swap items
                else //Take whats needed from mouse
                {
                    int remainingOnMouse = mouseInventoryItem.AssignedInventorySlot.StackSize - leftInStack;
                    clickedUISlot.AssignedInventorySlot.AddToStack(leftInStack);
                    clickedUISlot.UpdateUISlot();

                    var newItem = new InventorySlots(mouseInventoryItem.AssignedInventorySlot.ItemData, remainingOnMouse);
                    mouseInventoryItem.ClearSlot();
                    mouseInventoryItem.UpdateMouseSlot(newItem);
                    return;
                }
            }//If different, Swap items
            else if (!isSameItem)
            {
                SwapSlots(clickedUISlot);
                return;
            }
        }
    }
    //Swap items in Inventory slots (Mouse & Inventory)
    private void SwapSlots(InventorySlots_UI clickedUISlot) {
        var clonedSlot = new InventorySlots(mouseInventoryItem.AssignedInventorySlot.ItemData, mouseInventoryItem.AssignedInventorySlot.StackSize);
        mouseInventoryItem.ClearSlot();

        mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);

        clickedUISlot.ClearSlot();
        clickedUISlot.AssignedInventorySlot.AssignItem(clonedSlot);
        clickedUISlot.UpdateUISlot();
    }
}
