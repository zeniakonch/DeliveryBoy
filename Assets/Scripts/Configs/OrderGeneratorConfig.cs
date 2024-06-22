using System.Collections.Generic;
using InventorySystem.Items;
using OrdersSystem;
using OrdersSystem.Customer;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "NewOrderGeneratorConfig", menuName = "Game/Configs/OrderGeneratorConfig")]
    public class OrderGeneratorConfig : ScriptableObject
    {
        public List<OrderDifficultData> difficulties;
        public List<Vector2> points;
        /// <summary>
        /// Частота попыток получения заказа
        /// (раз в какое количество секунд пытаемся сгенерировать заказ)
        /// </summary>
        [Range(0.1f, 2f)] public float generationFrequency;
        /// <summary>
        /// Шанс генерации заказа раз в generationFrequency секунд
        /// </summary>
        [Range(0.1f, 1)] public float getOrderChance;
        /// <summary>
        /// Список всех предметов для заказов
        /// </summary>
        public List<ItemData> items;
        /// <summary>
        /// Шанс добавления продукта в корзину
        /// </summary>
        [Range(0.1f, 1)] public float addProductChance;
        /// <summary>
        /// Изменение шанса на добавление продукта в корзину
        /// </summary>
        [Range(0.1f, 1)] public float deltaAddProductChance;
        /// <summary>
        /// Максимальный шанс добавления продукта в корзину
        /// </summary>
        [Range(0.1f, 1)] public float maxAddProductChance;
        /// <summary>
        /// Раз в какое пройденное расстояние дается бонус
        /// </summary>
        [Min(0.1f)] public float distanceStep;
        /// <summary>
        /// Бонусное количество денег за дистанцию
        /// </summary>
        [Min(0)] public float bonusForDistance;
    }
}