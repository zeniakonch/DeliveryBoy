using System;
using OrdersSystem;
using Phone.Screens;
using Player;
using ServiceLocatorSystem;
using TMPro;
using UnityEngine;

namespace Phone
{
    public class DistanceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text distanceField;
        [SerializeField, Range(0, 3)] private float orderEndDistance;
        
        private PlayerScript _player;
        private OrderController _orderController;
        private PhoneView _phone;

        public void Initialize()
        {
            _player = ServiceLocator.Instance.Get<PlayerScript>();
            _orderController = ServiceLocator.Instance.Get<OrderController>();
            _phone = ServiceLocator.Instance.Get<PhoneView>();
        }

        public void UpdateDistance(Vector2 target)
        {
            int distance = (int)Vector2.Distance(_player.transform.position, target);
            distanceField.text = distance.ToString();

            if (distance <= orderEndDistance)
            {
                _orderController.Order = null;
                _phone.ShowScreen<MainScreen>();
            }
        }
    }
}