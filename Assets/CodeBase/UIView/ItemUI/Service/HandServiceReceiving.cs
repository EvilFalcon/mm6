using Items;
using UIView.InventoryUI;
using UIView.InventoryUI.Service;
using UIView.ItemUI.Presenter;
using UnityEngine;

namespace UIView.ItemUI.Service
{
    public class HandServiceReceiving
    {
        private readonly InventoryServiceItemAdditions _inventoryServiceItemAdditions;
        private readonly HandPresenter _handPresenter;
        private readonly FactorySprite _factorySprite;

        public HandServiceReceiving(InventoryServiceItemAdditions inventoryServiceItemAdditions, HandPresenter handPresenter, FactorySprite factorySprite)
        {
            _inventoryServiceItemAdditions = inventoryServiceItemAdditions;
            _handPresenter = handPresenter;
            _factorySprite = factorySprite;
        }

        public void PickUpItem(Item item)
        {
            if (_inventoryServiceItemAdditions.Push(new Vector2Int(1, 1), item))
                return;
        }
    }
}