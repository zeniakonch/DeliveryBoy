using InventorySystem.Items;
using UnityEngine;

namespace InventorySystem
{
    public class ItemSpawnManager : MonoBehaviour
    {
        public static ItemSpawnManager Instance;

        private void Awake()
        {
            Instance = this;
        }
    
        public void SpawnItem(Vector3 position, ItemData itemData, int count)
        {
            GameObject o = Instantiate(itemData.prefab, position, Quaternion.identity);
            o.GetComponent<Item>().Set(itemData, count);
        }
    }
}
