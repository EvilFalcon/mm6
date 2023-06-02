using System;
using Interface;
using Items.WeaponItem.WeaponComponent.DamageType;

namespace Items.WeaponItem.WeaponComponent
{
    public interface IDamage : IComponent
    {
        Type ApplyTo(Action<IDamageType> action);
    }
}