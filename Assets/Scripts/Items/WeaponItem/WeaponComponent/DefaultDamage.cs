using System;
using ComponentVisitor;
using Data.Utils;
using Items.WeaponItem.WeaponComponent.DamageType;

namespace Items.WeaponItem.WeaponComponent
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

        public int GetDamage()
        {
            return Dice.GetValueDice(DiceCount, SideCount) + Mod2;
        }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public Type ApplyTo(Action<IDamageType> action) =>
            typeof(T);
    }
}