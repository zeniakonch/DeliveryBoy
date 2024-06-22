using System.Collections.Generic;
using InventorySystem;
using OrdersSystem.Customer;
using Phone;
using Phone.Screens;
using SceneManagement;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.Events;

namespace OrdersSystem
{
    public class OrderController
    {
        private Order _order;
        private readonly Inventory _inventory = ServiceLocator.Instance.Get<Inventory>();
        private readonly PhoneView _phone = ServiceLocator.Instance.Get<PhoneView>();
        private readonly SceneManager _sceneManager = ServiceLocator.Instance.Get<SceneManager>();
        
        public UnityEvent OnOrderChange { get; private set; } = new();
        public Order Order
        {
            get => _order;
            set
            {
                if (_order != null && value == null)
                {
                    List<Slot> emptySlots = new List<Slot>();
                    for (int i = 0; i < _inventory.Slots.Length; i++)
                    {
                        emptySlots.Add(new Slot());
                    }
                    _inventory.Initialize(emptySlots);
                    
                    _phone.ShowScreen<MainScreen>();
                    _phone.GetScreen<MainScreen>().UpdateButtonsInteractStatus();
                }
                
                _order = value;
                OnOrderChange.Invoke();
            }
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            _order.Status = newStatus;
            OnOrderChange.Invoke();
        }

        public void UpdateArrow()
        {
            if (Order != null)
            {
                Vector2 position = Vector2.zero;
                switch (Order.Status)
                {
                    case OrderStatus.Accepted:
                        position = Order.OrderGiver.IsAtCurrentLocation() ? Order.OrderGiver.transform.position :
                            _sceneManager.GetSceneMoverAtCurrentLocation().transform.position;
                        break;
                    case OrderStatus.Delivery:
                        position = Order.Customer.IsAtCurrentLocation() ? Order.Customer.transform.position :
                            _sceneManager.GetSceneMoverAtCurrentLocation().transform.position;
                        break;
                }
                _phone.GetScreen<OrderInfoScreen>().point = position;   
            }
        }
    }
}