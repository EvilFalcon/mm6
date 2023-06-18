using Items;
using UIView.InventoryUI;
using UIView.ItemUI.Model;
using UnityEngine;

namespace UIView.ItemUI.Factory
{
    public class ItemHandFactory
    {
        private readonly SpriteFactory _spriteFactory;

        public ItemHandFactory()
        {
            _spriteFactory = new SpriteFactory();
        }

        public ItemHand Create(Item item)
        {
            Sprite sprite = _spriteFactory.Create(item.PicApSprite);
            return new ItemHand(item, sprite);
        }
    }
}