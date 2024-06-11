using System;
using OrdersSystem;
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

        public void Show(Order order)
        {
            gameObject.SetActive(true);
            customerNameField.text = order.CustomerName;
            priceField.text = order.Price.ToString();
        }

        public void OnAcceptButtonClicked()
        {
            
        }
    }
}