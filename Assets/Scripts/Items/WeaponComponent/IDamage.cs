using System;
using Interface;
using Items.WeaponComponent.DamageType;

namespace Items.WeaponComponent
{
    public interface IDamage : IComponent
    {
        Type ApplyTo(Action<IDamageType> action);
    }
}