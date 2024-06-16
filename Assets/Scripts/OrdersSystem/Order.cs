using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

namespace OrdersSystem
{
    public class Order
    {
        public OrderStatus Status;
        public OrderNumber Number;
        public Vector2 Point;
        public int Price;
        public string CustomerName;
        public OrderDifficultData Difficult;
        public List<Slot> Slots;
    }
}