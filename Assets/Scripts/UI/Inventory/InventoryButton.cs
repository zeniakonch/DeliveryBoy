using InventorySystem;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Inventory
{
    public class InventoryButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
    {
        private Item _item;
        public Slot Slot { get; private set; }
        private InventoryPanel _inventoryPanel;

        private void Awake()
        {
            _item = GetComponentInChildren<Item>();
            _item.Clear();
            _inventoryPanel = ServiceLocator.Instance.Get<InventoryPanel>();
        }

        public void Set(Slot newSlot)
        {
            Slot = newSlot;
            if (newSlot.itemData != null)
            {
                _item.Fill(newSlot.itemData.prefab.GetComponent<SpriteRenderer>().sprite, newSlot.count);
            }
            else
            {
                _item.Clear();
            }
        }

        public void Clear()
        {
            Slot.Clear();
            _item.Clear();
        }

        public void OnDrag(PointerEventData eventData)
        {
            DragAndDropSlot.Instance.ChangeRectTransform(eventData.delta / _inventoryPanel.Canvas.scaleFactor);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_item.Image.sprite != null)
            {
                DragAndDropSlot.Instance.Show(_item.Image.sprite, transform.localPosition);
                _item.gameObject.SetActive(false);    
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            DragAndDropSlot.Instance.Hide();
            _item.gameObject.SetActive(true);
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryButton otherButton = dropped.GetComponent<InventoryButton>();
            Slot cachedSlot = otherButton.Slot;
            otherButton.Set(Slot);
            Set(cachedSlot);
        }
    }
}