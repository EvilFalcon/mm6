using System;
using ComponentVisitor;
using Items.ItemComponent.WeaponComponent.DamageType;

namespace Items.ItemComponent.WeaponComponent
{
    public class DamageModified<T> : IDamage where T : IDamageType
    {
        public DamageModified(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; }
        public int Max { get; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public Type ApplyTo(Action<IDamageType> action) =>
            typeof(T);
    }
}