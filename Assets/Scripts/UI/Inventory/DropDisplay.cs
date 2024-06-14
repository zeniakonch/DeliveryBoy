using InventorySystem;
using Player;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Inventory
{
    public class DropDisplay : MonoBehaviour, IDropHandler, IService
    {
        private PlayerScript _player;

        public void Initialize()
        {
            _player = ServiceLocator.Instance.Get<PlayerScript>();
            gameObject.SetActive(false);
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryButton button = dropped.GetComponent<InventoryButton>();
            if (button.Slot.ItemData != null)
            {
                Vector2 playerPosition = _player.transform.position;
                ItemSpawnManager.Instance.SpawnItem(new Vector2(playerPosition.x + 5, playerPosition.y), button.Slot.ItemData, button.Slot.Count);
                button.Clear();   
            }
        }
    }
}