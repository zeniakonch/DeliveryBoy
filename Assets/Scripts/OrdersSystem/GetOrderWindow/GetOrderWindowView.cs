using System;
using InventorySystem;
using MVC;
using OrdersSystem.Customer;
using Phone;
using Phone.Screens;
using ServiceLocatorSystem;
using UnityEngine;

namespace OrdersSystem.GetOrderWindow
{
    public class GetOrderWindowView : ViewBase<GetOrderWindowModel, GetOrderWindowController>
    {
        private OrderController _orderController;
        private bool _isOutput = false;
        private PhoneView _phone;
        private Inventory _inventory;
        
        private void Start()
        {
            InitializeController(new GetOrderWindowController(model, this));
            InitializeNumbersButtons();
            model.orderNumberField.text = "";
            _orderController = ServiceLocator.Instance.Get<OrderGenerator>().OrderController;
            _phone = ServiceLocator.Instance.Get<PhoneView>();
            _inventory = ServiceLocator.Instance.Get<Inventory>();
            gameObject.SetActive(false);
        }

        private void InitializeNumbersButtons()
        {
            for (int i = 0; i < 10; i++)
            {
                NumberButton numberButton = Instantiate(model.numberButtonPrefab, model.buttons.transform).GetComponent<NumberButton>();
                numberButton.Initialize(i, OnInput);
            }
        }

        private void OnInput(int number)
        {
            HideOutput();
            
            model.orderNumberField.text += number;
            
            if (model.orderNumberField.text.Length > 6)
            {
                model.orderNumberField.text = model.orderNumberField.text.Substring(0, 6);
            }
        }

        public void OnDelete()
        {
            HideOutput();
            
            if (model.orderNumberField.text.Length > 0)
            {
                model.orderNumberField.text = model.orderNumberField.text.Substring(0, model.orderNumberField.text.Length - 1);   
            }
        }

        public void OnSend()
        {
            HideOutput();
            
            if (_orderController.Order is null or { Status: OrderStatus.InProcessing })
            {
                ShowOutput(model.noOrderError);
            }
            else if (model.orderNumberField.text.Length < 6)
            {
                ShowOutput(model.notEnoughNumbersError);
            }
            else if (model.orderNumberField.text != _orderController.Order.Number.ToString())
            {
                ShowOutput(model.incorrectOrderNumberError);
            }
            else
            {
                ShowOutput(model.acceptSentence);
                _orderController.ChangeStatus(OrderStatus.Delivery);
                _phone.ShowScreen<OrderInfoScreen>();
                
                _orderController.UpdateArrow();
                _inventory.Initialize(_orderController.Order.Slots);
            }
        }

        public void OnClose()
        {
            HideOutput();
            model.orderNumberField.text = "";
            gameObject.SetActive(false);
        }

        private void ShowOutput(Output output)
        {
            model.orderNumberField.text = output.text;
            model.orderNumberField.color = output.color;
            _isOutput = true;
        }

        private void HideOutput()
        {
            if (_isOutput)
            {
                model.orderNumberField.text = "";
                model.orderNumberField.color = Color.white;
                _isOutput = false;   
            }
        }
    }
}