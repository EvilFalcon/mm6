using System;
using System.Collections.Generic;
using ComponentVisitor;
using Interface;

namespace PlayerScripts.PlayerComponent.Equipment
{
    public class HeroEquipment : IComponent
    {
        private Dictionary<Type, IEquipmentItems> _items = new Dictionary<Type, IEquipmentItems>();

        public void Set(IEquipmentItems items)
        {
            _items.Add(_items.GetType(), items);
        }

        public void Accept(IComponentVisitor visitor)
        {
            foreach (var value in _items.Values)
            {
                value.Accept(visitor);
            }
        }
    }
}