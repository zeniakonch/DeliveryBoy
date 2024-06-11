using System;
using Configs;
using Phone;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace InputSystem
{
    public class InputController : MonoBehaviour, IService
    {
        [FormerlySerializedAs("data")] [SerializeField] 
        private InputConfig config;
        private PhoneView _phone;
        private bool _isInitialized = false;

        public void Initialize()
        {
            _phone = ServiceLocator.Instance.Get<PhoneView>();
            _isInitialized = true;
        }
        
        private void Update()
        {
            if (_isInitialized)
            {
                if (Input.GetKeyDown(config.phoneKey))
                {
                    if (_phone.gameObject.activeSelf)
                    {
                        _phone.Hide();
                    }
                    else
                    {
                        _phone.Show();
                    }
                }   
            }
        }
    }
}