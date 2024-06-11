using System;
using InputSystem;
using Phone;
using UnityEngine;

namespace ServiceLocatorSystem
{
    public class ServiceLocatorLoader : MonoBehaviour
    {
        [SerializeField] 
        private PhoneView phone;
        [SerializeField] 
        private InputController inputController;
        
        private void Awake()
        {
            RegisterServices();
            Initialize();
        }

        private void RegisterServices()
        {
            ServiceLocator.Initialize();
            
            ServiceLocator.Instance.Register(phone);
            ServiceLocator.Instance.Register(inputController);
        }

        private void Initialize()
        {
            ServiceLocator.Instance.Get<PhoneView>().Initialize();
            ServiceLocator.Instance.Get<InputController>().Initialize();
        }
    }
}