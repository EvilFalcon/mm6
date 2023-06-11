using System;
using System.Collections.Generic;

namespace PlayerScripts.PlayerComponent.Equipment
{
    public class HeroEquipment
    {
        private Dictionary<Type, IEquipmentItems> _items = new Dictionary<Type, IEquipmentItems>();

        public void Set(IEquipmentItems items)
        {
            _items.Add(_items.GetType(), items);
        }
    }
}