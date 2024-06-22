using System.Collections.Generic;
using InventorySystem;
using OrdersSystem.Customer;
using OrdersSystem.OrderGiver;
using UnityEngine;

namespace OrdersSystem
{
    public class Order
    {
        public OrderStatus Status;
        public OrderNumber Number;
        public Vector2 Point;
        public int Price;
        public CustomerBehaviour Customer;
        public OrderGiverView OrderGiver;
        public OrderDifficultData Difficult;
        public List<Slot> Slots;
    }
}