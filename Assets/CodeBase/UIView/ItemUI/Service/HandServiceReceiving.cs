using Items;
using UIView.InventoryUI;
using UIView.InventoryUI.Service;
using UIView.ItemUI.Factory;
using UIView.ItemUI.Presenter;

namespace UIView.ItemUI.Service
{
    public class HandServiceReceiving
    {
        private readonly InventoryServiceItemAdditions _inventoryServiceItemAdditions;
        private readonly HandPresenter _handPresenter;
        private readonly ItemHandFactory _itemHandFactory;
        private readonly FactorySprite _factorySprite;
        private Item _item;

        public HandServiceReceiving(
            HandPresenterFactory handPresenterFactory,
            ItemHandFactory itemHandFactory)
        {
            _handPresenter = handPresenterFactory.Create();
            _itemHandFactory = itemHandFactory;
        }

        public void Push(Item item)
        {
            _item = item;
            _handPresenter.SetItem(_itemHandFactory.Create(item));
            _handPresenter.Enable();
        }

        public Item Pull()
        {
            _handPresenter.Disable();
            return _item;
        }
    }
}