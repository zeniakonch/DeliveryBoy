using System;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorSystem
{
    /// <summary>
    /// Класс-замена singleton (паттерн service locator)
    /// </summary>
    public class ServiceLocator
    {
        private ServiceLocator(){}
        
        public static ServiceLocator Instance { get; private set; }
        /// <summary>
        /// Словарь со всеми зарегистрированными сервисами
        /// </summary>
        private readonly Dictionary<string, IService> _services = new();

        public static void Initialize()
        {
            Instance = new ServiceLocator();
        }

        /// <summary>
        /// Получает сервис указанного типа
        /// </summary>
        public T Get<T>() where T : IService
        {
            if (!_services.ContainsKey(typeof(T).Name))
            {
                Debug.LogError($"Service locator doesn't find service {typeof(T).Name}");
                throw new Exception();
            }

            return (T)_services[typeof(T).Name];
        }

        /// <summary>
        /// Регистрирует сервис указанного типа
        /// </summary>
        public void Register<T>(T service) where T : IService
        {
            string key = typeof(T).Name;
            if (!_services.TryAdd(key, service))
            {
                Debug.LogError($"Service locator already have service {key}");
            }
        }

        /// <summary>
        /// Удаляет сервис указанного типа
        /// </summary>
        public void Unregister<T>() where T : IService
        {
            if (!_services.ContainsKey(typeof(T).Name))
            {
                Debug.LogError($"Service locator doesn't have service {typeof(T).Name}");
                return;
            }
            _services.Remove(typeof(T).Name);
        }
    }
}