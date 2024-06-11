using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class Item : MonoBehaviour
    {
        [field: SerializeField] public Image Image { get; private set; }
        [SerializeField] private TMP_Text count;

        public void Clear()
        {
            Image.color = Color.clear;
            count.text = "";
        }

        public void Fill(Sprite newSprite, int newCount)
        {
            Image.sprite = newSprite;
            Image.color = Color.white;
            count.text = newCount.ToString();
        }
    }
}