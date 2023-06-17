using UnityEngine;

namespace UIView
{
    public class SpriteFactory
    {
        public Sprite Create(string name)
        {
            return Resources.Load<Sprite>(name);
        }
    }
}