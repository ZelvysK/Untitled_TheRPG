using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlots_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlots assignedInventorySlot;

    private Button button;

    public InventorySlots AssignedInventorySlot => assignedInventorySlot;
    public InventoryDisplay ParentDisplay { get; private set; }

    private void Awake() {
        ClearSlot();

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        ParentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    public void Init(InventorySlots slot) {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlots slot) {
        if (slot.ItemData != null)
        {
            //Update sprite
            itemSprite.sprite = slot.ItemData.Icon;
            itemSprite.color = Color.white;
            //Update amount
            if (slot.StackSize > 1) itemCount.text = slot.StackSize.ToString();
            else itemCount.text = string.Empty;
        }
        else
        {
            ClearSlot();
        }

    }

    public void UpdateUISlot() {
        if (assignedInventorySlot != null) UpdateUISlot(assignedInventorySlot);
    }

    public void ClearSlot() {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = string.Empty;
    }

    public void OnUISlotClick() {
        ParentDisplay?.SlotClicked(this);
    }
}
