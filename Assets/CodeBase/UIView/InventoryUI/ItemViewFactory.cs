using UIView.InventoryUI.View;
using UnityEngine;

namespace UIView.InventoryUI
{
    public class ItemViewFactory
    {
        public ItemView Create()
        {
            return GameObject.Instantiate(Resources.Load<ItemView>("Infrastructure/ItemView"));
        }
    }
}