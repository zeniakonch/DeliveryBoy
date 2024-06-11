using System;
using Data;
using UnityEngine;

namespace InventorySystem.Items
{
    public abstract class Item : MonoBehaviour
    {
        public ItemData itemData;
        public int count = 1;
        [SerializeField] protected float pickUpDistance = 1.5f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, pickUpDistance);
        }

        public void Set(ItemData itemsData, int counts)
        {
            itemData = itemsData;
            count = counts;

            SpriteRenderer component = GetComponent<SpriteRenderer>();
            component.sprite = itemData.prefab.GetComponent<SpriteRenderer>().sprite;
        }
    }
}