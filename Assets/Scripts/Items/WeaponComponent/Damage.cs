using System;
using ComponentVisitor;
using Items.WeaponComponent.DamageType;

namespace Items.WeaponComponent
{
    public class Damage<T> : IDamage where T : IDamageType
    {
        public Damage(float min, float max)
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