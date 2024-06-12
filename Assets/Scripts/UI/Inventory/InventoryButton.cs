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
        private InventorySystem.Inventory _inventory;
        [SerializeField] private RectTransform rectTransform;

        private void Awake()
        {
            _item = GetComponentInChildren<Item>();
            _item.Clear();
            _inventoryPanel = ServiceLocator.Instance.Get<InventoryPanel>();
            _inventory = ServiceLocator.Instance.Get<InventorySystem.Inventory>();
        }

        public void Set(Slot newSlot)
        {
            Slot = newSlot;
            if (newSlot.ItemData != null)
            {
                _item.Fill(newSlot.ItemData.prefab.GetComponent<SpriteRenderer>().sprite, newSlot.Count);
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
                DragAndDropSlot.Instance.Show(_item.Image.sprite, rectTransform.anchoredPosition);
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
            _inventory.ReplaceSlots(Slot, otherButton.Slot);
            _inventoryPanel.UpdateInventory();
        }
    }
}