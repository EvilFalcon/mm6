using Data.Utils;
using UnityEngine;

namespace UIView
{
    public class ConverterInventory
    {
        public Vector2Int GetSize(Sprite sprite)
        {
            float width = sprite.textureRect.width / Constants.CellSizeSprite - 0.5f;
            float height = sprite.textureRect.height / Constants.CellSizeSprite - 0.5f;

            return new Vector2Int(Mathf.CeilToInt(width), Mathf.CeilToInt(height));
        }
    }
}