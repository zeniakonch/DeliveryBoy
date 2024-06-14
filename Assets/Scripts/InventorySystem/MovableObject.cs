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
        private PlayerScript _player;

        public void Start()
        {
            _inventory = ServiceLocator.Instance.Get<Inventory>();
            _player = ServiceLocator.Instance.Get<PlayerScript>();
        }

        public void PickUp()
        {
            if (Vector2.Distance(_player.transform.position, transform.position) <= pickUpDistance)
            {
                _inventory.Add(itemData);
                Destroy(gameObject);
            }
        }
    }
}
