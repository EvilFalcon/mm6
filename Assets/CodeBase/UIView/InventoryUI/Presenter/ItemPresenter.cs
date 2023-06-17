using Data.Utils;
using UIView.InventoryUI.View;
using UIView.Model;
using UnityEngine;

namespace UIView.InventoryUI.Presenter
{
    public class ItemPresenter : IPresenter
    {
        private readonly ItemView _view;
        private readonly InventoryItem _item;
        private readonly InventoryView _inventoryView;
        private readonly FactorySprite _factorySprite;

        public ItemPresenter(ItemView view, InventoryItem item, InventoryView inventoryView)
        {
            _view = view;
            _item = item;
            _inventoryView = inventoryView;
            _view.SetSprite(_item.Sprite);
            _view.SetParent(inventoryView.GetComponent<RectTransform>());
        }

        private float Scale => _inventoryView.Scale;

        public void Enable()
        {
            Update();
            _view.Show();
        }

        public void Disable()
        {
            _view.Hide();
        }

        public void Update()
        {
            Vector2 size = _item.Sprite.textureRect.size * Scale;
            float rectScale = Constants.CellSizeSprite * Scale;

            Vector2 rectSize = (Vector2)_item.RectSize * rectScale;
            Vector2 center = (Vector2)_item.Position * rectScale + rectSize / 2;
            center.y *= -1;
            
            _view.SetSize(size);
            _view.SetPosition(center);
        }

        public bool IsEqual(InventoryItem item)
        {
            return _item.Item == item.Item;
        }
    }
}