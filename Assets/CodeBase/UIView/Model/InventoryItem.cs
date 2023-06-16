using Items;
using UnityEngine;

namespace UIView.Model
{
    public class InventoryItem
    {
        public InventoryItem(Item item, RectInt rect,Sprite sprite)
        {
            Item = item;
            Rect = rect;
            Sprite = sprite;
        }

        public Item Item { get; }
        public RectInt Rect { get; }
        public Sprite Sprite { get; }
        public Vector2Int Position => Rect.position;
        public Vector2Int RectSize => Rect.size;
    }
}