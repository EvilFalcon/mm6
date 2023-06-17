using UnityEngine;
using UnityEngine.UI;

namespace UIView.View
{
    [RequireComponent(typeof(Image))]
    public class ItemView : MonoBehaviour
    {
        private Image _image;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetParent(RectTransform rectTransform)
        {
            _rectTransform.parent = rectTransform;
        }
        
        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void SetPosition(Vector2 center)
        {
            _rectTransform.anchoredPosition = center;
        }

        public void SetSize(Vector2 size)
        {
            _rectTransform.sizeDelta = size;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}