using System;
using Player;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem.Items
{
    public class PickUpItem : Item
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float tll = 10f;
        private Inventory _inventory;
        private PlayerScript _player;

        private void Start()
        {
            _player = ServiceLocator.Instance.Get<PlayerScript>();
            _inventory = ServiceLocator.Instance.Get<Inventory>();
        }

        private void Update()
        {
            tll -= Time.deltaTime;
            if (tll < 0)
            {
                Destroy(gameObject);
            }

            float distance = Vector3.Distance(transform.position, _player.transform.position);
            if (distance > pickUpDistance)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                _player.transform.position,
                speed * Time.deltaTime);
            if (distance < 0.1f)
            {
                _inventory.Add(itemData, count);
                
                Destroy(gameObject);
            }
        }
    }
}
