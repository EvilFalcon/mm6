using System;
using Interface;
using Items.ItemComponent.WeaponComponent.DamageType;

namespace Items.ItemComponent.WeaponComponent
{
    public interface IDamage : IComponent
    {
        Type ApplyTo(Action<IDamageType> action);
    }
}