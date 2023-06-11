using UnityEngine;
using UnityEngine.UI;

namespace InventoryComponent
{
    public class InventoryView : MonoBehaviour, IView
    {
        private Image _image;

        public float Scale => _image.rectTransform.rect.width / _image.sprite.rect.width;

        private void Awake()
        {
            _image = GetComponent<Image>();
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