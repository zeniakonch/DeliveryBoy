using InventorySystem;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Inventory
{
    public class DropDisplay : MonoBehaviour, IDropHandler
    {
        public static DropDisplay Instance;

        private void Awake()
        {
            Instance = this;
            gameObject.SetActive(false);
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("drop");
            GameObject dropped = eventData.pointerDrag;
            InventoryButton button = dropped.GetComponent<InventoryButton>();
            Vector2 playerPosition = PlayerScript.Instance.transform.position;
            ItemSpawnManager.Instance.SpawnItem(new Vector2(playerPosition.x + 5, playerPosition.y), button.Slot.itemData, button.Slot.count);
            button.Clear();
        }
    }
}