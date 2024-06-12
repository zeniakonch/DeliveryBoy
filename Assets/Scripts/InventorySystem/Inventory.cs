using System;
using System.Collections.Generic;
using InventorySystem.Items;
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

        public void Initialize(List<Slot> newSlots)
        {
            for (int i = 0; i < newSlots.Count; i++)
            {
                Slots[i] = newSlots[i];
            }
            
            OnChangeSlot.Invoke();
        }

        public void ReplaceSlots(Slot fromSlot, Slot toSlot)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i] == fromSlot)
                {
                    Slots[i] = toSlot;
                }
                else if (Slots[i] == toSlot)
                {
                    Slots[i] = fromSlot;
                }
            }
        }

        public void Add(ItemData itemData, int count = 1)
        {
            Slot slot;
            if (itemData.stackCount > 1)
            {
                slot = Array.Find(Slots,x => x.ItemData == itemData);
                if (slot == null)
                {
                    slot = Array.Find(Slots,x => x.ItemData == null);
                }
            }
            else
            {
                slot = Array.Find(Slots,x => x.ItemData == null);
                
            }
            slot.Set(itemData, count);
            OnChangeSlot.Invoke();
        }
    }
}
