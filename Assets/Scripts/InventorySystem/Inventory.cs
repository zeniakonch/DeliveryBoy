using System;
using Data;
using ServiceLocatorSystem;
using UI.Inventory;
using UnityEngine.Events;

namespace InventorySystem
{
    public class Inventory : IService
    {
        public readonly UnityEvent OnChangeSlot = new();
        public Slot[] Slots;
        private InventoryPanel _inventoryPanel;

        public void Initialize()
        {
            _inventoryPanel = ServiceLocator.Instance.Get<InventoryPanel>();
            Slots = new Slot[_inventoryPanel.CountSlots];
            for (int i = 0; i < Slots.Length; i++)
            {
                Slots[i] = new Slot();
            }
        }

        public void Add(ItemData itemData, int count = 1)
        {
            Slot slot;
            if (itemData.stackable == true)
            {
                slot = Array.Find(Slots,x => x.itemData == itemData);
                if (slot == null)
                {
                    slot = Array.Find(Slots,x => x.itemData == null);
                }
            }
            else
            {
                slot = Array.Find(Slots,x => x.itemData == null);
                
            }
            slot.Set(itemData, count);
            OnChangeSlot.Invoke();
        }
    }
}
