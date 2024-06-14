using ServiceLocatorSystem;
using UnityEngine.Events;

namespace OrdersSystem
{
    public class OrderController : IService
    {
        private Order _order;
        
        public UnityEvent OnOrderChange { get; private set; } = new();
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnOrderChange.Invoke();
            }
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            _order.Status = newStatus;
            OnOrderChange.Invoke();
        }
    }
}