using System;
using System.Collections.Generic;
using InventorySystem;
using OrdersSystem;
using Phone.Screens;
using ServiceLocatorSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Phone
{
    public class OrderView : MonoBehaviour
    {
        [SerializeField] private TMP_Text customerNameField;
        [SerializeField] private TMP_Text priceField;
        [SerializeField] private TMP_Text difficultField;
        
        private PhoneView _phone;
        private OrderController _orderController;
        
        public void Initialize()
        {
            _orderController = ServiceLocator.Instance.Get<OrderGenerator>().OrderController;
            _phone = ServiceLocator.Instance.Get<PhoneView>();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void Show()
        {
            Order order = _orderController.Order;
            
            gameObject.SetActive(true);
            if (order != null)
            {
                customerNameField.text = order.Customer.CustomerName;
                priceField.text = order.Price.ToString();
                difficultField.text = order.Difficult.difficultName;
            }
        }

        public void OnAcceptButtonClicked()
        {
            _orderController.ChangeStatus(OrderStatus.Accepted);
            Order order = _orderController.Order;
            
            if (order != null)
            {
                _phone.ShowScreen<OrderInfoScreen>();
                _phone.GetScreen<OrderInfoScreen>().ShowOrderInfo();
                _orderController.UpdateArrow();
            }
        }
    }
}