using UnityEngine;

namespace UIView
{
    public class FactorySprite
    {
        public Sprite Create(string picApSprite)
        {
            return Resources.Load<Sprite>(picApSprite);
        }
    }
}