using System;
using OrdersSystem;
using Player;
using ServiceLocatorSystem;
using TMPro;
using UnityEngine;

namespace Phone.Screens
{
    public class OrderInfoScreen : ScreenBase
    {
        [SerializeField] private TMP_Text customerNameField;
        [SerializeField] private TMP_Text priceField;
        [SerializeField] private TMP_Text numberField;
        [SerializeField] private Arrow arrow;
        [SerializeField] private DistanceView distanceView;

        private OrderController _orderController;

        public override void Initialize()
        {
            base.Initialize();
            arrow.Initialize();
            distanceView.Initialize();
            
            _orderController = ServiceLocator.Instance.Get<OrderController>();
        }

        private void Update()
        {
            Order order = _orderController.Order;

            if (order == null) return;
            
            arrow.UpdateDirection(order.Point);
            distanceView.UpdateDistance(order.Point);
        }

        public void ShowOrderInfo()
        {
            Order order = _orderController.Order;
            
            customerNameField.text = order.CustomerName;
            priceField.text = order.Price.ToString();
            numberField.text = order.Number.ToString();
        }
    }
}