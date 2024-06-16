using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OrdersSystem.GetOrderWindow
{
    public class NumberButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text numberField;
        [SerializeField] private Button button;

        public void Initialize(int number, UnityAction<int> inputNumber)
        {
            numberField.text = number.ToString();
            button.onClick.AddListener(() => inputNumber(number));
        }
    }
}