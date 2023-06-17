using UnityEngine;

namespace UIView.InventoryUI
{
    public class SpriteFactory
    {
        public Sprite Create(string name)
        {
            return Resources.Load<Sprite>(name);
        }
    }
}