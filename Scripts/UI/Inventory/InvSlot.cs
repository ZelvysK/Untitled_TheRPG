using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour
{
    public Image itemImage;
    [SerializeField] private TextMeshProUGUI stackSizeText;

    public void ClearSlot() {
        itemImage.enabled = false;
        stackSizeText.enabled = false;
    }
    public void DrawSlot(InventoryItem item) {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        itemImage.enabled = true;
        stackSizeText.enabled = true;

        itemImage.sprite = item.itemSO.itemSprite;
        stackSizeText.text = item.stackSize.ToString();
    }
}
