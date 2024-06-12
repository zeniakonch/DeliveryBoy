using System;
using InventorySystem.Items;
using Player;
using ServiceLocatorSystem;
using UnityEngine;

namespace InventorySystem
{
    public class MovableObject : Item
    {
        private Inventory _inventory;
        
        private void Awake()
        {
            _inventory = ServiceLocator.Instance.Get<Inventory>();
        }

        public void PickUp()
        {
            if (Vector2.Distance(PlayerScript.Instance.transform.position, transform.position) <= pickUpDistance)
            {
                _inventory.Add(itemData);
                Destroy(gameObject);
            }
        }
    }
}
