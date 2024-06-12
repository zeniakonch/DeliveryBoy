using System.Collections.Generic;
using OrdersSystem;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "NewOrderGeneratorConfig", menuName = "Game/Configs/OrderGeneratorConfig")]
    public class OrderGeneratorConfig : ScriptableObject
    {
        public List<OrderDifficultData> difficulties;
        /// <summary>
        /// Частота попыток получения заказа
        /// (раз в какое количество секунд пытаемся сгенерировать заказ)
        /// </summary>
        [Range(0.1f, 2f)]
        public float generationFrequency;
        /// <summary>
        /// Шанс генерации заказа раз в generationFrequency секунд
        /// </summary>
        [Range(0, 1)]
        public float getOrderChance;
    }
}