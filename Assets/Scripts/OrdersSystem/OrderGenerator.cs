using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using InventorySystem;
using InventorySystem.Items;
using OrdersSystem.Customer;
using OrdersSystem.OrderGiver;
using Phone;
using Phone.Screens;
using ServiceLocatorSystem;
using UI.Inventory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OrdersSystem
{
    public class OrderGenerator : MonoBehaviour, IService
    {
        [SerializeField] private List<CustomerBehaviour> customers;
        [SerializeField] private List<OrderGiverView> givers;
        
        public OrderController OrderController { get; private set; }
        
        private bool _isGenerating;
        private SearchOrderScreen _screen;
        private InventoryPanel _inventoryPanel;
        private Inventory _inventory;
        private OrderGeneratorConfig _config;

        public void Initialize()
        {
            _screen = ServiceLocator.Instance.Get<PhoneView>().GetScreen<SearchOrderScreen>();
            _inventoryPanel = ServiceLocator.Instance.Get<InventoryPanel>();
            _config = _screen.OrderGeneratorConfig;
            OrderController = new OrderController();
        }
        
        public IEnumerator Generate()
        {
            _isGenerating = true;
            while (_isGenerating)
            {
                yield return new WaitForSeconds(_config.generationFrequency);
                float randomValue = Random.value;
                if (randomValue <= _config.getOrderChance)
                {
                    OrderDifficultData difficult = _config.difficulties[Random.Range(0, _config.difficulties.Count)];
                    List<Slot> slots = GenerateItems(difficult);
                    
                    Order newOrder = new()
                    {
                        Status = OrderStatus.InProcessing,
                        Number = new OrderNumber(),
                        OrderGiver = givers[Random.Range(0, givers.Count)],
                        Price = GetPrice(slots),
                        Customer = customers[Random.Range(0, customers.Count)],
                        Point = _config.points[Random.Range(0, _config.points.Count)],
                        Difficult = difficult,
                        Slots = slots
                    };

                    OrderController.Order = newOrder;
                    _isGenerating = false;
                }
            }
        }

        private List<Slot> GenerateItems(OrderDifficultData difficult)
        {
            List<Slot> slots = new();
            List<ItemData> availableItems = new(_config.items);
            for (int i = 0; i < _inventoryPanel.CountSlots; i++)
            {
                slots.Add(new Slot());
            }
            
            float currentChance = _config.addProductChance;
            
            /*
             * Пока вес заказа меньше минимального веса для данной сложности мы
             * добавляем случайные товары в заказ (либо если больше нельзя вместить товары, а
             * минимальный вес не достигнут выдается ошибка), при этом шанс добавления продукта
             * растет на каждой итерации
             */
            while (GetWeight(slots) < difficult.minWeight && availableItems.Count > 0)
            {
                for (int i = 0; i < availableItems.Count; i++)
                {
                    float randomValue = Random.value;
                    if (randomValue <= currentChance)
                    {
                        if (GetWeight(slots) + availableItems[i].weight > difficult.maxWeight ||
                            !TryAddItem(slots, availableItems[i]))
                        {
                            availableItems.RemoveAt(i);
                            break;
                        }
                        
                        currentChance += _config.deltaAddProductChance;
                        if (currentChance > _config.maxAddProductChance)
                        {
                            currentChance = _config.maxAddProductChance;
                        }
                    }
                }
            }

            if (availableItems.Count == 0 && GetWeight(slots) < difficult.minWeight)
            {
                Debug.LogError("Can't be generated order with this items");
                throw new Exception();
            }
            
            return slots;
        }

        private bool TryAddItem(List<Slot> slots, ItemData item)
        {
            foreach (var slot in slots)
            {
                if (slot.ItemData == null)
                {
                    slot.Set(item);
                    return true;
                } 
                if (slot.ItemData == item)
                {
                    if (slot.TryAdd(1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private float GetWeight(List<Slot> slots)
        {
            float weight = 0;
            foreach (var slot in slots)
            {
                if (slot.ItemData != null)
                {
                    weight += slot.ItemData.weight * slot.Count;
                }
            }

            return weight;
        }

        private int GetPrice(List<Slot> slots)
        {
            int price = 0;
            
            foreach (var slot in slots)
            {
                if (slot.ItemData != null)
                {
                    price += slot.ItemData.price * slot.Count;
                }
            }

            return price;
        }
    }
}