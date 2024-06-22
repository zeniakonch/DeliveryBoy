using System;
using InputSystem;
using InventorySystem;
using OrdersSystem;
using OrdersSystem.Customer;
using Phone;
using Player;
using SceneManagement;
using UI.Inventory;
using UnityEngine;

namespace ServiceLocatorSystem
{
    public class ServiceLocatorLoader : MonoBehaviour
    {
        [SerializeField] private PhoneView phone;
        [SerializeField] private InputController inputController;
        [SerializeField] private InventoryPanel inventoryPanel;
        [SerializeField] private PlayerScript player;
        [SerializeField] private DropDisplay dropDisplay;
        [SerializeField] private OrderGenerator orderGenerator;
        [SerializeField] private SceneManager sceneManager;
        
        private void Awake()
        {
            RegisterServices();
            Initialize();
        }

        private void RegisterServices()
        {
            ServiceLocator.Initialize();
            
            ServiceLocator.Instance.Register(orderGenerator);
            ServiceLocator.Instance.Register(player);
            ServiceLocator.Instance.Register(dropDisplay);
            ServiceLocator.Instance.Register(phone);
            ServiceLocator.Instance.Register(inputController);
            ServiceLocator.Instance.Register(inventoryPanel);
            ServiceLocator.Instance.Register(sceneManager);
            
            ServiceLocator.Instance.Register(new Inventory());
        }

        private void Initialize()
        {
            ServiceLocator.Instance.Get<OrderGenerator>().Initialize();
            ServiceLocator.Instance.Get<DropDisplay>().Initialize();
            ServiceLocator.Instance.Get<PhoneView>().Initialize();
            ServiceLocator.Instance.Get<InputController>().Initialize();
            ServiceLocator.Instance.Get<InventoryPanel>().Initialize();
            ServiceLocator.Instance.Get<Inventory>().Initialize();
        }
    }
}