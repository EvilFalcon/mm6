using UnityEngine;

namespace UIView.InventoryUI
{
    public class FactorySprite
    {
        public Sprite Create(string picApSprite)
        {
            return Resources.Load<Sprite>(picApSprite);
        }
    }
}