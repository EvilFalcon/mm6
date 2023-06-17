using System;
using Items;

namespace UIView.InventoryUI
{
    public class InventorySlot
    {
        private Item _item;
        private string _picFile;

        public void AddItem(Item item)
        {
            if (item == null)
                throw new NullReferenceException();

            if (_item != null)
                return;

            _item = item;
            _picFile = item.PicApSprite;
        }
    }
}