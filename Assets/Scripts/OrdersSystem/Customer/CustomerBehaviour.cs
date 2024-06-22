using Player;
using SceneManagement;
using ServiceLocatorSystem;
using UnityEngine;

namespace OrdersSystem.Customer
{
    public class CustomerBehaviour : MonoBehaviour
    {
        [SerializeField, Min(0.1f)] private float activateDistance;
        
        [field: SerializeField] public string CustomerName { get; private set; }
        [field: SerializeField] public Location Location { get; private set; }

        private PlayerScript _player;
        private OrderController _orderController;
        private SceneManager _sceneManager;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, activateDistance);
        }
        
        private void Start()
        {
            _player = ServiceLocator.Instance.Get<PlayerScript>();
            _orderController = ServiceLocator.Instance.Get<OrderGenerator>().OrderController;
            _sceneManager = ServiceLocator.Instance.Get<SceneManager>();
        }

        private void Update()
        {
            if (Vector2.Distance(_player.transform.position, transform.position) <= activateDistance &&
                _orderController.Order is { Status: OrderStatus.Delivery } && CustomerName == _orderController.Order.Customer.CustomerName)
            {
                _orderController.Order = null;
            }
        }
        
        public bool IsAtCurrentLocation()
        {
            if (_sceneManager.currentLocation == Location)
            {
                return true;
            }

            return false;
        }
    }
}