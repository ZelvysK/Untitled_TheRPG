using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [Tooltip("This is used for Skills & other stuff that shouldn't be swaped")]
    [SerializeField] public bool staticStorage;

    [SerializeField] protected List<InventorySlot> slots = new List<InventorySlot>();
    [SerializeField] protected List<ItemSO> items = new List<ItemSO>();

    private InventorySlot swapSlot;

    private void Start() {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].UpdateUI(items[i]);
            slots[i].SetupStorage(this);
            slots[i].SetupMouseControl(this);
        }
    }

    internal void SwapItem(InventorySlot targetSlot) {
        if (swapSlot == null)
        {
            swapSlot = targetSlot;
        }
        else if (swapSlot == targetSlot)
        {
            swapSlot = null;
        }
        else
        {
            Storage storage1 = swapSlot.GetStorage();
            int index1 = storage1.GetItemIndex(swapSlot);
            ItemSO item1 = storage1.GetItem(index1);

            Storage storage2 = swapSlot.GetStorage();
            int index2 = storage2.GetItemIndex(swapSlot);
            ItemSO item2 = storage2.GetItem(index2);

            if (!storage1.staticStorage)
            {
                storage1.SetItemSlot(index1, item2);
                swapSlot.UpdateUI(item2);
            }
            if (!storage2.staticStorage)
            {
                storage2.SetItemSlot(index2, item1);
                swapSlot.UpdateUI(item1);
            }

            swapSlot = null;
        }
    }

    internal void ClearSwap() => swapSlot = null;

    private int GetItemIndex(InventorySlot inventorySlot) => slots.IndexOf(inventorySlot);
    private ItemSO GetItem(int index) => items[index];
    private void SetItemSlot(int index, ItemSO item) => items[index] = item;
}
