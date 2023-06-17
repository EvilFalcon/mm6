using Items;
using UIView.InventoryUI.Presenter;
using UIView.Model;
using UnityEngine;

namespace UIView.InventoryUI.Service
{
    public class InventoryServiceItemAdditions
    {
        private readonly ItemFillPlacer _itemFillPlacer;
        private readonly SpriteFactory _spriteFactory;
        private readonly ConverterInventory _converterInventory;
        private readonly InventoryRepository _repository;
        private readonly InventoryPresenter _presenter;

        public InventoryServiceItemAdditions(
            InventoryRepository repository,
            InventoryPresenter presenter,
            ItemFillPlacer itemFillPlacer,
            SpriteFactory spriteFactory
        )
        {
            _itemFillPlacer = itemFillPlacer;
            _spriteFactory = spriteFactory;
            _repository = repository;
            _presenter = presenter;
            _converterInventory = new ConverterInventory();
        }

        public bool Push(Vector2Int position, Item item)
        {
            Sprite sprite = _spriteFactory.Create(item.PicApSprite);
            Vector2Int size = _converterInventory.GetSize(sprite);
            RectInt rect = new RectInt(position, size);

            if (_itemFillPlacer.CanPutRect(rect))
            {
                InventoryItem itemInventory = Create(item, rect, sprite);
                _repository.SetItem(itemInventory);
                _presenter.Add(itemInventory);
                return true;
            }

            if (_itemFillPlacer.FindSuitablePlace(rect, out Vector2Int newPosition))
            {
                RectInt newRect = new RectInt(newPosition, size);

                InventoryItem itemInventory = Create(item, newRect, sprite);
                _repository.SetItem(itemInventory);
                _presenter.Add(itemInventory);
                _presenter.Update();
                return true;
            }

            return false;
        }

        private InventoryItem Create(Item item, RectInt rect, Sprite sprite)
        {
            return new InventoryItem(item, rect, sprite);
        }

        public Item Pull(Vector2Int position)
        {
            InventoryItem inventoryItem = _repository.Pull(position);
            _presenter.Remove(inventoryItem);

            return inventoryItem.Item;
        }
    }
}