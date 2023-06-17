using UnityEngine;

namespace UIView
{
    public class ItemFillPlacer
    {
        private readonly InventoryRepository _repository;
        private readonly RectInt _rect;

        public ItemFillPlacer(InventoryRepository repository, Vector2Int size)
        {
            _repository = repository;
            _rect = new RectInt(Vector2Int.zero, size);
        }
        
        public bool FindSuitablePlace(RectInt rect, out Vector2Int position)
        {
            bool[,] mask = CreateMask();

            for (int x = 0; x < mask.GetLength(0) - rect.x; x++)
            for (int y = 0; y < mask.GetLength(1) - rect.y; y++)
                if (CanFill(x, y, rect, mask))
                {
                    position = new Vector2Int(x, y);
                    return true;
                }

            position = default;
            return false;
        }
        
        public bool CanPutRect(RectInt rect)
        {
            if (TryFitInArea(rect) == false)
                return false;

            return TryFitInInventory(rect);
        }

        private bool CanFill(int xPosition, int yPosition, RectInt rect, bool[,] mask)
        {
            for (int x = 0; x < rect.width; x++)
            for (int y = 0; y < rect.height; y++)
                if (mask[x + xPosition, y + yPosition])
                    return false;

            return true;
        }

        private bool[,] CreateMask()
        {
            bool[,] mask = new bool[_rect.width, _rect.height];

            foreach (var item in _repository.GetAll)
            {
                FillMask(item.Rect, mask);
            }

            return mask;
        }

        private void FillMask(RectInt rect, bool[,] mask)
        {
            for (int x = 0; x < rect.width; x++)
            for (int y = 0; y < rect.height; y++)
                mask[x + rect.x, y + rect.y] = true;
        }

        private bool TryFitInInventory(RectInt rect)
        {
            bool canSet = true;

            foreach (var item1 in _repository.GetAll)
            {
                if (item1.Rect.Overlaps(rect))
                {
                    canSet = false;
                }
            }

            return canSet;
        }

        private bool TryFitInArea(RectInt rect)
        {
            if (rect.yMax > _rect.yMax)
                return false;

            if (rect.yMin < _rect.yMin)
                return false;

            if (rect.xMax > _rect.xMax)
                return false;

            if (rect.xMin < _rect.xMin)
                return false;

            return true;
        }
    }
}