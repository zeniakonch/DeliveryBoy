using System;
using System.Collections.Generic;
using Configs;
using InventorySystem;
using OrdersSystem;
using OrdersSystem.OrderGiver;
using SceneManagement;
using ServiceLocatorSystem;
using TMPro;
using UnityEngine;

namespace Phone.Screens
{
    public class SearchOrderScreen : ScreenBase
    {
        [SerializeField] private TMP_Text searchField;
        [SerializeField] private OrderView orderView;
        [SerializeField] private OrderGiverView giver;
        
        [field: SerializeField] public OrderGeneratorConfig OrderGeneratorConfig { get; private set; }
        
        private Coroutine _activeOrderGenerating;
        private OrderGenerator _orderGenerator;
        private OrderController _orderController;

        public override void Initialize()
        {
            base.Initialize();
            orderView.Initialize();
            _orderGenerator = ServiceLocator.Instance.Get<OrderGenerator>();
            _orderController = _orderGenerator.OrderController;
            _orderController.OnOrderChange.AddListener(ShowOrder);
            Debug.Log(_orderGenerator);
        }

        public override void Show()
        {
            base.Show();
            if (_activeOrderGenerating != null)
            {
                StopCoroutine(_activeOrderGenerating);
            }
            
            searchField.gameObject.SetActive(true);
            orderView.Hide();
            
            _activeOrderGenerating = StartCoroutine(_orderGenerator.Generate());
        }

        public override void Hide()
        {
            if (_activeOrderGenerating != null)
            {
                StopCoroutine(_activeOrderGenerating);
            }
            
            base.Hide();
        }

        private void ShowOrder()
        {
            if (giver != null)
            {
                Phone.GetScreen<OrderInfoScreen>().point = giver.transform.position;
            }
            else
            {
                Phone.GetScreen<OrderInfoScreen>().point = _orderController.Order.Point;
            }
            
            searchField.gameObject.SetActive(false);
            orderView.Show();
        }
    }
}