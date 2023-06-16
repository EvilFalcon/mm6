using System.Collections.Generic;
using Items;
using UIView.Model;
using UnityEngine;

namespace UIView
{
    public class InventoryRepository
    {
        private List<InventoryItem> _items = new List<InventoryItem>();
        public InventoryItem[] GetAll => _items.ToArray();

        public void SetItem(InventoryItem item) =>
            _items.Add(item);

        public InventoryItem Pull(Vector2Int position)
        {
            InventoryItem item = FindByPosition(position);

            if (_items.Remove(item))
                return item;

            return default;
        }

        private InventoryItem FindByPosition(Vector2Int position)
        {
            foreach (var item in _items)
            {
                if (item.Rect.Contains(position))
                {
                    return item;
                }
            }

            return default;
        }
    }
}