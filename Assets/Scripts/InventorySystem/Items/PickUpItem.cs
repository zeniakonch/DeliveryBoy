using Data;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem.Items
{
    public class PickUpItem : Item
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float tll = 10f;

        private void Update()
        {
            tll -= Time.deltaTime;
            if (tll < 0)
            {
                Destroy(gameObject);
            }

            float distance = Vector3.Distance(transform.position, PlayerScript.Instance.transform.position);
            if (distance > pickUpDistance)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                PlayerScript.Instance.transform.position,
                speed * Time.deltaTime);
            if (distance < 0.1f)
            {
                Inventory.GetInstance().Add(itemData, count);
                
                Destroy(gameObject);
            }
        }
    }
}
