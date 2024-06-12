using System;
using OrdersSystem;
using Phone.Screens;
using ServiceLocatorSystem;
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
        private PhoneView _phone;
        
        public void Initialize()
        {
            _phone = ServiceLocator.Instance.Get<PhoneView>();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void Show(Order order)
        {
            gameObject.SetActive(true);
            customerNameField.text = order.CustomerName;
            priceField.text = order.Price.ToString();
            difficultField.text = order.Difficult.difficultName;
        }

        public void OnAcceptButtonClicked()
        {
            _phone.ShowScreen<OrderInfoScreen>();
            _phone.GetScreen<MainScreen>().StartWorkButton.interactable = false;
        }
    }
}