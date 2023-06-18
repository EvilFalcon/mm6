using UIView.ItemUI.View;
using UnityEngine;

namespace UIView.ItemUI.Factory
{
    public class HandViewFactory
    {
        public HandView Create()
        {
            return Object.Instantiate(Resources.Load<HandView>("Infrastructure/HandItemView"));
        }
    }
}