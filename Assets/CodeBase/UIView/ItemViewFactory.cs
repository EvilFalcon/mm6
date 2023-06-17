using UIView.View;
using UnityEngine;

namespace UIView
{
    public class ItemViewFactory
    {
        public ItemView Create()
        {
            return GameObject.Instantiate(Resources.Load<ItemView>("Infrastructure/ItemView"));
        }
    }
}