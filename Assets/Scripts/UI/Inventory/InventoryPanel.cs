using System.Collections.Generic;
using ServiceLocatorSystem;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryPanel : MonoBehaviour, IService
    {
        private InventorySystem.Inventory _inventory;
        private DropDisplay _dropDisplay;
        private readonly List<InventoryButton> _buttons = new ();
        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private GameObject slotsPanel; 
        [field: SerializeField] public Canvas Canvas { get; private set; }
        [field:SerializeField, Min(1)] public int CountSlots { get; private set; }

        public void Initialize ()
        {
            _inventory = ServiceLocator.Instance.Get<InventorySystem.Inventory>();
            _dropDisplay = ServiceLocator.Instance.Get<DropDisplay>();
            
            _inventory.OnChangeSlot.AddListener(UpdateInventory);
            for (int i = 0; i < CountSlots; i++)
            {
                _buttons.Add(Instantiate(buttonPrefab, slotsPanel.transform).GetComponent<InventoryButton>());
                _buttons[^1].transform.SetParent(slotsPanel.transform);
            }
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            if (_inventory != null)
            {
                _dropDisplay.gameObject.SetActive(true);
                UpdateInventory();
            }
        }

        private void OnDisable()
        {
            if (_dropDisplay != null)
            {
                _dropDisplay.gameObject.SetActive(false);
            }
        }

        public void UpdateInventory()
        {
            if (_inventory == null || _buttons.Count == 0) return;

            for (int i = 0; i < _inventory.Slots.Length; i++)
            {
                _buttons[i].Set(_inventory.Slots[i]);
            }
        }
    }
}
