using System;
using System.Collections.Generic;
using System.Linq;
using Phone.Screens;
using ServiceLocatorSystem;
using UnityEngine;

namespace Phone
{
    public class PhoneView : MonoBehaviour, IService
    {
        [SerializeField] private List<ScreenBase> screens;

        /// <summary>
        /// При изменении списка screens убираем окна одинакового типа
        /// </summary>
        private void OnValidate()
        {
            for (int i = 0; i < screens.Count; i++)
            {
                for (int j = i + 1; j < screens.Count; j++)
                {
                    if (screens[i] != null && screens[j] != null &&
                        screens[i].GetType() == screens[j].GetType())
                    {
                        screens[j] = null;
                    }
                }
            }
        }

        public void Initialize()
        {
            foreach (var screen in screens)
            {
                screen.Initialize();    
            }
            
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ShowScreen<MainScreen>();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void ShowScreen<T>() where T : ScreenBase
        {
            foreach (var screen in screens)
            {
                if (typeof(T) == screen.GetType())
                {
                    screen.Show();
                }
                else
                {
                    screen.Hide();   
                }
            }
        }

        public T GetScreen<T>() where T : ScreenBase
        {
            foreach (var screen in screens)
            {
                if (screen.GetType() == typeof(T))
                {
                    return (T)screen;
                }
            }
            
            Debug.LogError($"Screen {typeof(T).Name} didn't find");
            throw new Exception();
        }
    }
}
