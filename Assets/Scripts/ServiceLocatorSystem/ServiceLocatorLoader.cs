using System;
using InputSystem;
using InventorySystem;
using Phone;
using UI.Inventory;
using UnityEngine;

namespace ServiceLocatorSystem
{
    public class ServiceLocatorLoader : MonoBehaviour
    {
        [SerializeField] private PhoneView phone;
        [SerializeField] private InputController inputController;
        [SerializeField] private InventoryPanel inventoryPanel;
        
        private void Awake()
        {
            RegisterServices();
            Initialize();
        }

        private void RegisterServices()
        {
            ServiceLocator.Initialize();
            
            ServiceLocator.Instance.Register(phone);
            ServiceLocator.Instance.Register(inputController);
            ServiceLocator.Instance.Register(inventoryPanel);
            ServiceLocator.Instance.Register(new Inventory());
        }

        private void Initialize()
        {
            ServiceLocator.Instance.Get<PhoneView>().Initialize();
            ServiceLocator.Instance.Get<InputController>().Initialize();
            ServiceLocator.Instance.Get<InventoryPanel>().Initialize();
            ServiceLocator.Instance.Get<Inventory>().Initialize();
        }
    }
}