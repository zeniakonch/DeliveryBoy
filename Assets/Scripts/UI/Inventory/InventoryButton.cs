using InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Inventory
{
    public class InventoryButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
    {
        private Item _item;
        [SerializeField] private Canvas canvas;
        public Slot Slot { get; private set; }

        private void Awake()
        {
            _item = GetComponentInChildren<Item>();
            _item.Clear();
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
            Debug.Log("clear");
            Slot.Clear();
            _item.Clear();
        }

        public void OnDrag(PointerEventData eventData)
        {
            DragAndDropSlot.Instance.ChangeRectTransform(eventData.delta / canvas.scaleFactor);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            RectTransform itemRect = _item.Image.rectTransform;
            DragAndDropSlot.Instance.Show(_item.Image.sprite, transform.localPosition);
            _item.gameObject.SetActive(false);
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