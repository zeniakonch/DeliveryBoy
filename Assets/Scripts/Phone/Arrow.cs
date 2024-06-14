using OrdersSystem;
using Player;
using ServiceLocatorSystem;
using UnityEngine;

namespace Phone
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        private PlayerScript _player;
        
        public void Initialize()
        {
            _player = ServiceLocator.Instance.Get<PlayerScript>();
        }

        public void UpdateDirection(Vector2 target)
        {
            Vector2 playerPosition = _player.transform.position;
            Quaternion rotation = rectTransform.rotation;
            
            Vector2 direction = target - new Vector2(playerPosition.x, playerPosition.y);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rectTransform.rotation = Quaternion.Euler(rotation.x, rotation.y, angle);
        }
    }
}