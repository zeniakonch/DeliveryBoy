using System;
using System.Collections.Generic;
using OrdersSystem;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Phone.Screens
{
    public class MainScreen : ScreenBase
    {
        [field: SerializeField] public Button StartWorkButton { get; private set; }
        [field: SerializeField] public Button ViewOrderInfoButton { get; private set; }

        private OrderController _orderController;

        public override void Initialize()
        {
            base.Initialize();
            _orderController = ServiceLocator.Instance.Get<OrderGenerator>().OrderController;
            _orderController.OnOrderChange.AddListener(UpdateButtonsInteractStatus);
            UpdateButtonsInteractStatus();
        }

        /// <summary>
        /// При нажатии на кнопку начала работы
        /// </summary>
        public void OnStartWorkClicked()
        {
            Phone.ShowScreen<SearchOrderScreen>();
        }

        /// <summary>
        /// При нажатии на кнопку просмотра информации об активном заказе
        /// </summary>
        public void OnViewOrderInfoClicked()
        {
            Phone.ShowScreen<OrderInfoScreen>();
        }

        public void UpdateButtonsInteractStatus()
        {
            if (_orderController.Order is { Status: OrderStatus.Accepted } or {Status: OrderStatus.Delivery})
            {
                StartWorkButton.interactable = false;
                ViewOrderInfoButton.interactable = true;
            }
            else
            {
                StartWorkButton.interactable = true;
                ViewOrderInfoButton.interactable = false;
            }
        }
    }
}