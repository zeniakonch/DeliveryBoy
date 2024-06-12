using System;
using System.Collections.Generic;
using Configs;
using OrdersSystem;
using TMPro;
using UnityEngine;

namespace Phone.Screens
{
    public class SearchOrderScreen : ScreenBase
    {
        [SerializeField] private TMP_Text searchField;
        [SerializeField] private OrderView orderView;
        [field: SerializeField] public OrderGeneratorConfig OrderGeneratorConfig { get; private set; }

        private readonly OrderGenerator _orderGenerator = new();
        private Coroutine _activeOrderGenerating;

        public override void Initialize()
        {
            base.Initialize();
            _orderGenerator.Initialize();
            orderView.Initialize();
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

        public void ShowOrder(Order order)
        {
            searchField.gameObject.SetActive(false);
            orderView.Show(order);
        }
    }
}