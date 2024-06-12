using System;
using InventorySystem.Items;
using UnityEngine.Serialization;

namespace InventorySystem
{
    [Serializable]
    public class Slot
    {
        public ItemData ItemData { get; private set; }
        public int Count { get; private set; }

        public void Copy(Slot slot)
        {
            ItemData = slot.ItemData;
            Count = slot.Count;
        }

        public void Set(ItemData newItemData, int newCount)
        {
            ItemData = newItemData;
            Count = newCount;
        }
        
        public void Set(ItemData newItemData)
        {
            ItemData = newItemData;
            Count = 1;
        }

        public bool TryAdd(int addCount)
        {
            if (Count + addCount > ItemData.stackCount)
            {
                return false;
            }
            
            Count += addCount;
            return true;
        }

        public void Clear()
        {
            ItemData = null;
            Count = 0;
        }
    }
}