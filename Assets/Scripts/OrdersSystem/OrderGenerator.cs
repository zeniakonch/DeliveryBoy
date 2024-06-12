using System.Collections;
using System.Collections.Generic;
using Configs;
using Phone;
using Phone.Screens;
using ServiceLocatorSystem;
using UnityEngine;

namespace OrdersSystem
{
    public class OrderGenerator
    {
        private bool _isGenerating;
        private SearchOrderScreen _screen;

        public void Initialize()
        {
            _screen = ServiceLocator.Instance.Get<PhoneView>().GetScreen<SearchOrderScreen>();
        }
        
        public IEnumerator Generate(OrderGeneratorConfig config)
        {
            _isGenerating = true;
            while (_isGenerating)
            {
                yield return new WaitForSeconds(1);
                float randomValue = Random.value;
                if (randomValue <= config.getOrderChance)
                {
                    OrderDifficultData difficult = config.difficulties[Random.Range(0, config.difficulties.Count)];
                    
                    Order order = new()
                    {
                        Price = 100,
                        CustomerName = "Сыроварский",
                        Point = new Vector2(0, 0),
                        Difficult = difficult
                    };
                    _screen.ShowOrder(order);
                    _isGenerating = false;
                }
            }
        }
    }
}