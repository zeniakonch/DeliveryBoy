using UnityEngine;

namespace InventorySystem.Items
{
    [CreateAssetMenu(fileName = "NewItem",menuName = "Game/Items/Item")]
    public class ItemData : ScriptableObject
    {
        public string naming;
        public GameObject prefab;
        public ItemType type;
        [Range(1, 99)] public int stackCount;
        [Min(1)] public int price;
        [Min(0.01f)] public float weight;
    }
}
