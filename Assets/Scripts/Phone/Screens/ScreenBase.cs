using System;
using ServiceLocatorSystem;
using UnityEngine;

namespace Phone.Screens
{
    public abstract class ScreenBase : MonoBehaviour
    {
        protected PhoneView Phone;
        
        public virtual void Initialize()
        {
            Phone = ServiceLocator.Instance.Get<PhoneView>();
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}