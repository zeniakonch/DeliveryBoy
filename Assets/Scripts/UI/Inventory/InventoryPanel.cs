using System.Collections.Generic;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryPanel : MonoBehaviour
    {
        private global::InventorySystem.Inventory _inventory; 
        [SerializeField] private GameObject buttonPrefab;
        private readonly List<InventoryButton> _buttons = new ();
        public static InventoryPanel Instance { get; private set; }
        [SerializeField] private GameObject slotsPanel; 

        [field:SerializeField, Min(1)] public int CountSlots { get; private set; }
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Initialize();
        }

        public void Initialize ()
        {
            _inventory = global::InventorySystem.Inventory.GetInstance();
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
                DropDisplay.Instance.gameObject.SetActive(true);
                UpdateInventory();
            }
        }

        private void OnDisable()
        {
            if (DropDisplay.Instance != null)
            {
                DropDisplay.Instance.gameObject.SetActive(false);
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
