using System;
using Data;
using InventorySystem.Items;
using Player;
using UnityEngine;

namespace InventorySystem
{
    public class MovableObject : Item
    {
        public void PickUp()
        {
            if (Vector2.Distance(PlayerScript.Instance.transform.position, transform.position) <= pickUpDistance)
            {
                Inventory.GetInstance().Add(itemData);
                Destroy(gameObject);
            }
        }
    }
}
