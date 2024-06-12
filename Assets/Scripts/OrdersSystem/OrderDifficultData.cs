using UnityEngine;

namespace OrdersSystem
{
    [CreateAssetMenu(fileName = "NewOrderDifficult", menuName = "Game/OrderDifficult")]
    public class OrderDifficultData : ScriptableObject
    {
        public string difficultName;
        [Range(1, 50)]
        public int minWeight;
        [Range(1, 50)]
        public int maxWeight;
        /// <summary>
        /// Множитель для данной сложности (например для увеличения/уменьшения наград)
        /// </summary>
        [Range(0.5f, 10)]
        public float multiplier;
    }
}