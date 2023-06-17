using UIView.InventoryUI.Presenter;
using UIView.InventoryUI.View;
using UIView.Model;

namespace UIView.InventoryUI
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