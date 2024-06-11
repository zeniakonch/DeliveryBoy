using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    [RequireComponent(typeof(Image), typeof(RectTransform))]
    public class DragAndDropSlot : MonoBehaviour
    {
        public static DragAndDropSlot Instance { get; private set; }
        private Image _image;
        private RectTransform _rectTransform;
        
        private void Awake()
        {
            Instance = this;
            _image = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();
            gameObject.SetActive(false);
        }

        public void ChangeRectTransform(Vector2 delta)
        {
            _rectTransform.anchoredPosition += delta;
        }

        public void Show(Sprite sprite, Vector2 position)
        {
            gameObject.SetActive(true);
            _image.sprite = sprite;
            _rectTransform.anchoredPosition = position;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}