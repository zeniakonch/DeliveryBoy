using TrafficLightScript;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    
    public class PlayerScript : MonoBehaviour
    {
        
        public Collider2D Collider { get; private set; }
        
        public SpriteRenderer SpriteRenderer { get; private set; }
        public static PlayerScript Instance { get; private set; }

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Collider = GetComponent<Collider2D>();
            Instance = this;
        }

        private void Update()
        {
            Ray2D ray = new Ray2D(transform.position, transform.right*3);
            Debug.DrawRay(ray.origin, ray.direction);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit && Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("TrafficLight"))
            {
                hit.collider.GetComponent<TrafficLightInteraction>().InteractedWithTrafficLight();
            } 
        }
    }
}
