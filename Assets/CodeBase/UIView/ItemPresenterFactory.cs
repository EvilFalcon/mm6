using UIView.Model;
using UIView.Presenter;
using UIView.View;
using UnityEngine;

namespace UIView
{
    public class ItemPresenterFactory
    {
        private readonly ItemViewFactory _viewFactory;
        private readonly InventoryView _inventoryView;

        public ItemPresenterFactory(ItemViewFactory viewFactory, InventoryView inventoryView)
        {
            _viewFactory = viewFactory;
            _inventoryView = inventoryView;
        }

        public ItemPresenter Create(InventoryItem item)
        {
            ItemView itemView = _viewFactory.Create();

            return new ItemPresenter(itemView, item,_inventoryView);
        }
    }
}