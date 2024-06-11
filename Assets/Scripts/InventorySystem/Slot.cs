using System;
using Data;
using InventorySystem.Items;
using UnityEngine.Serialization;

namespace InventorySystem
{
    [Serializable]
        
    public class Slot
    {
        public ItemData itemData;
        public int count;

        public void Copy(Slot slot)
        {
            itemData = slot.itemData;
            count = slot.count;
        }

        public void Set(ItemData newItemData, int newCount)
        {
            itemData = newItemData;
            count = newCount;
        }

        public void Clear()
        {
            itemData = null;
            count = 0;
        }
    }
}