using System.Collections;
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
        
        public IEnumerator Generate(float chance)
        {
            _isGenerating = true;
            while (_isGenerating)
            {
                yield return new WaitForSeconds(1);
                float randomValue = Random.value;
                if (randomValue <= chance)
                {
                    Order order = new()
                    {
                        Price = 100,
                        CustomerName = "Сыроварский",
                        Point = new Vector2(0, 0),
                        Difficult = OrderDifficult.Medium
                    };
                    _screen.ShowOrder(order);
                    _isGenerating = false;
                }
            }
        }
    }
}