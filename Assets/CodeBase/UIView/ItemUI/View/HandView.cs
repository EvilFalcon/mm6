using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UIView.ItemUI.View
{
    [RequireComponent(
        typeof(RectTransform),
        typeof(Image))]
    public class HandView : MonoBehaviour
    {
        private Image _image;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();

            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rectTransform.anchoredPosition = Mouse.current.position.value;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}