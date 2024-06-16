using MVC;
using Player;
using ServiceLocatorSystem;
using UnityEngine;

namespace OrdersSystem.OrderGiver
{
    public class OrderGiverController : ControllerBase<OrderGiverModel, OrderGiverView>
    {
        private readonly PlayerScript _player;
        
        public OrderGiverController(OrderGiverModel model, OrderGiverView view) : base(model, view)
        {
            _player = ServiceLocator.Instance.Get<PlayerScript>();
        }

        public bool IsAvailableToActivate()
        {
            return Vector2.Distance(_player.transform.position, View.transform.position) <= Model.activateDistance;
        }
    }
}