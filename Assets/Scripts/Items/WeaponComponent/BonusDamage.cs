using System;
using ComponentVisitor;
using Items.WeaponComponent.DamageType;

namespace Items.WeaponComponent
{
    public class BonusDamage<T> : IDamage where T : IDamageType
    {
        public BonusDamage(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public float Min { get; }
        public float Max { get; }

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