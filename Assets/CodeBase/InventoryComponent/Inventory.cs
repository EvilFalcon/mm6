using System.Collections.Generic;
using Items;
using UnityEngine;

namespace InventoryComponent
{
    public class Inventory
    {
        // private bool[,] _inventorySlots = new bool[9, 14];

        // public void AddItem(Item item)
        // {
        //     var size = item.Image.size;
        //     item.Image.size = size;
        // }

        private List<Item> _items = new List<Item>();

        public void SetItem(Vector2Int position, Item item)
        {
            
        }

        public Item GetItem(Vector2Int position)
        {
            return null;
        }
    }
}