using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlots_UI : MonoBehaviour
{
    //REFERENCES
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlots assignedInventorySlot;
    private Button button;

    //FIELDS
    public InventorySlots AssignedInventorySlot => assignedInventorySlot;
    public InventoryDisplay ParentDisplay { get; private set; }

    private void Awake() {
        ClearSlot();

        itemSprite.preserveAspect = true;

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        ParentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }
    //Initialize Inventory slot
    public void Init(InventorySlots slot) {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }
    //Update Inventory slot
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
    //If the button is clicked
    public void OnUISlotClick() {
        ParentDisplay?.SlotClicked(this);
    }
}
