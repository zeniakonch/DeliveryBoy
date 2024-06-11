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
        [SerializeField] private ChancesConfig chancesConfig;
        [SerializeField] private TMP_Text searchField;
        [SerializeField] private OrderView orderView;

        private readonly OrderGenerator _orderGenerator = new();
        private Coroutine _activeOrderGenerating;

        public override void Initialize()
        {
            base.Initialize();
            _orderGenerator.Initialize();
        }

        public override void Show()
        {
            base.Show();
            if (_activeOrderGenerating != null)
            {
                StopCoroutine(_activeOrderGenerating);
            }
            
            _activeOrderGenerating = StartCoroutine(_orderGenerator.Generate(chancesConfig.getOrderChance));
        }

        public override void Hide()
        {
            if (_activeOrderGenerating != null)
            {
                StopCoroutine(_activeOrderGenerating);
            }
            
            searchField.gameObject.SetActive(true);
            orderView.gameObject.SetActive(false);
            base.Hide();
        }

        public void ShowOrder(Order order)
        {
            searchField.gameObject.SetActive(false);
            orderView.Show(order);
        }
    }
}