using System;
using TMPro;
using UnityEngine;

namespace Interaction
{
    public class InteractionKey : MonoBehaviour
    {
        [SerializeField] private TMP_Text inputKeyField;

        public void SetKey(KeyCode key)
        {
            inputKeyField.text = key.ToString();
            gameObject.SetActive(false);
        }
    }
}