using System;
using MVC;
using SceneManagement;
using ServiceLocatorSystem;
using UnityEngine;

namespace OrdersSystem.OrderGiver
{
    public class OrderGiverView : ViewBase<OrderGiverModel, OrderGiverController>
    {
        [field: SerializeField] public string GiverName { get; private set; }
        [field: SerializeField] public Location Location { get; private set; }

        private SceneManager _sceneManager;
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, model.activateDistance);
        }

        private void Start()
        {
            InitializeController(new OrderGiverController(model, this));
            model.interactionKey.SetKey(model.inputConfig.interactKey);
            _sceneManager = ServiceLocator.Instance.Get<SceneManager>();
        }

        private void Update()
        {
            model.interactionKey.gameObject.SetActive(Controller.IsAvailableToActivate());

            if (model.interactionKey.gameObject.activeSelf && Input.GetKeyDown(model.inputConfig.interactKey))
            {
                model.getOrderWindow.gameObject.SetActive(true);
            }
        }

        public bool IsAtCurrentLocation()
        {
            if (_sceneManager.currentLocation == Location)
            {
                return true;
            }

            return false;
        }
    }
}