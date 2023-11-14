using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Storage storage;
    private InventorySlot inventorySlot;
    private GameObject dragInstance;

    public void SetupStorage(Storage storage, InventorySlot inventorySlot) {
        this.storage = storage;

    }

    public void OnBeginDrag(PointerEventData eventData) {
        storage.SwapItem(inventorySlot);

        dragInstance = new GameObject("Drag" + inventorySlot.name);
        var image = dragInstance.AddComponent<Image>();

        image.sprite = inventorySlot.itemImage.sprite;
        image.raycastTarget = false;

        dragInstance.transform.SetParent(storage.transform);
        dragInstance.transform.localScale = Vector3.one;
    }

    public void OnDrag(PointerEventData eventData) {
        if (dragInstance != null)
        {
            dragInstance.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (eventData.pointerCurrentRaycast.gameObject is GameObject targetObj)
        {
            var targetSlot = targetObj.GetComponent<InventorySlot>();
            if (targetSlot != null)
            {
                storage.SwapItem(targetSlot);
                EventSystem.current.SetSelectedGameObject(targetObj);
            }
            storage.ClearSwap();
        }

        if (dragInstance != null)
        {
            Destroy(dragInstance);
        }
    }
}
