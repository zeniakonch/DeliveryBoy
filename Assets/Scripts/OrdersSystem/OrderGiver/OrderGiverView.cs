using System;
using MVC;
using UnityEngine;

namespace OrdersSystem.OrderGiver
{
    public class OrderGiverView : ViewBase<OrderGiverModel, OrderGiverController>
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, model.activateDistance);
        }

        private void Start()
        {
            InitializeController(new OrderGiverController(model, this));
            model.interactionKey.SetKey(model.inputConfig.interactKey);
        }

        private void Update()
        {
            model.interactionKey.gameObject.SetActive(Controller.IsAvailableToActivate());

            if (model.interactionKey.gameObject.activeSelf && Input.GetKeyDown(model.inputConfig.interactKey))
            {
                model.getOrderWindow.gameObject.SetActive(true);
            }
        }
    }
}