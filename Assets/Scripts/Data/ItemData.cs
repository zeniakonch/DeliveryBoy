using InventorySystem.Items;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Item")]
    public class ItemData : ScriptableObject
    {
        public string naming;
        public bool stackable;
        public GameObject prefab;
        public ItemType type;
    }
}
