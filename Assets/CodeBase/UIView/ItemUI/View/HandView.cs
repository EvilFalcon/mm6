using UnityEngine;
using UnityEngine.UI;

namespace UIView.ItemUI.View
{
    public class HandView : MonoBehaviour
    {
        private Image _image;

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

        public void SetPosition(Vector2 position)
        {
            transform.position = new Vector3(position.x, position.y);
        }
    }
}