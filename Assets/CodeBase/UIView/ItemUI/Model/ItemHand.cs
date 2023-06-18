using Items;
using UnityEngine;

namespace UIView.ItemUI.Model
{
    public class ItemHand
    {
        public ItemHand(Item item, Sprite sprite)
        {
            Item = item;
            Sprite = sprite;
        }

        public Item Item { get; }
        public Sprite Sprite { get; }
    }
}