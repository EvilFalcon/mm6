using System;
using ComponentVisitor;
using Items.WeaponItem.WeaponComponent.DamageType;

namespace Items.WeaponItem.WeaponComponent
{
    public class BonusDamage<T> : IDamage where T : IDamageType
    {
        public BonusDamage(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public Type ApplyTo(Action<IDamageType> action)
        {
            return typeof(T);
        }
    }
}