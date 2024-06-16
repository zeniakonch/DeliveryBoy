using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OrdersSystem.GetOrderWindow
{
    [Serializable]
    public class GetOrderWindowModel
    {
        public GameObject numberButtonPrefab;
        public GameObject buttons;
        public TMP_Text orderNumberField;
        public Output noOrderError;
        public Output incorrectOrderNumberError;
        public Output notEnoughNumbersError;
        public Output acceptSentence;
    }
}