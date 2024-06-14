using System;
using System.Collections.Generic;
using Configs;
using InventorySystem;
using OrdersSystem;
using ServiceLocatorSystem;
using TMPro;
using UnityEngine;

namespace Phone.Screens
{
    public class SearchOrderScreen : ScreenBase
    {
        [SerializeField] private TMP_Text searchField;
        [SerializeField] public OrderView orderView;
        [field: SerializeField] public OrderGeneratorConfig OrderGeneratorConfig { get; private set; }
        
        private Coroutine _activeOrderGenerating;
        private OrderGenerator _orderGenerator;
        private OrderController _orderController;

        public override void Initialize()
        {
            base.Initialize();
            orderView.Initialize();
            _orderGenerator = ServiceLocator.Instance.Get<OrderGenerator>();
            _orderController = ServiceLocator.Instance.Get<OrderController>();
            
            _orderController.OnOrderChange.AddListener(ShowOrder);
        }

        public override void Show()
        {
            base.Show();
            if (_activeOrderGenerating != null)
            {
                StopCoroutine(_activeOrderGenerating);
            }
            
            _activeOrderGenerating = StartCoroutine(_orderGenerator.Generate());
        }

        public override void Hide()
        {
            if (_activeOrderGenerating != null)
            {
                StopCoroutine(_activeOrderGenerating);
            }
            
            searchField.gameObject.SetActive(true);
            orderView.Hide();
            base.Hide();
        }

        private void ShowOrder()
        {
            searchField.gameObject.SetActive(false);
            orderView.Show();
        }
    }
}