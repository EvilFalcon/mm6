using UIView.Model;
using UnityEngine;
using UnityEngine.UI;

namespace UIView.View
{
    public class InventoryView : MonoBehaviour, IView
    {
        private Image _image;

        public float Scale => _image.rectTransform.rect.width / _image.sprite.rect.width;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Show(InventoryItem[] inventoryItems)
        {
            gameObject.SetActive(true);

            foreach (var item in inventoryItems)
            {
                
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}