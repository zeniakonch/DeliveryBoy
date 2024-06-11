using System;
using Data;
using UI.Inventory;
using UnityEngine.Events;

namespace InventorySystem
{
    public class Inventory
    {
        private static Inventory _instance;
        public readonly UnityEvent OnChangeSlot = new();
        public Slot[] Slots;

        public static Inventory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Inventory();

                _instance.Slots = new Slot[InventoryPanel.Instance.CountSlots];

                for (int i = 0; i < _instance.Slots.Length; i++)
                {
                    _instance.Slots[i] = new Slot();
                }
            }

            return _instance;
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
