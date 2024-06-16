using System;
using Configs;
using Interaction;
using OrdersSystem.GetOrderWindow;
using UnityEngine;
using UnityEngine.Serialization;

namespace OrdersSystem.OrderGiver
{
    [Serializable]
    public class OrderGiverModel
    {
        [Min(0.1f)] public float activateDistance;
        public InputConfig inputConfig;
        public InteractionKey interactionKey;
        public GetOrderWindowView getOrderWindow;
    }
}