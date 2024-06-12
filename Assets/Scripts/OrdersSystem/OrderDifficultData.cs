using UnityEngine;

namespace OrdersSystem
{
    [CreateAssetMenu(fileName = "NewOrderDifficult", menuName = "Game/OrderDifficult")]
    public class OrderDifficultData : ScriptableObject
    {
        public string difficultName;
    }
}