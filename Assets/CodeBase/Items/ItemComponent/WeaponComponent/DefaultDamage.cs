using System;
using ComponentVisitor;
using Items.ItemComponent.WeaponComponent.DamageType;

namespace Items.ItemComponent.WeaponComponent
{
    public class DefaultDamage<T> : IDamage where T : IDamageType
    {
        public DefaultDamage(int diceCount, int sideCount, int mod2)
        {
            DiceCount = diceCount;
            SideCount = sideCount;
            Mod2 = mod2;
        }

        public int DiceCount { get; }
        public int SideCount { get; }
        public int Mod2 { get; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public Type ApplyTo(Action<IDamageType> action) =>
            typeof(T);
    }
}