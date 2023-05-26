using System;
using System.Collections.Generic;
using Items.WeaponComponent;
using Items.WeaponComponent.DamageType;

namespace ComponentVisitor
{
    public class DamageVisitor : AbstractVisitor
    {
        private readonly Dictionary<Type, IDamage> _components = new Dictionary<Type, IDamage>();

        public override void Visit<T>(BonusDamage<T> bonusDamage)
        {
            Type type = typeof(T);

            if (_components.ContainsKey(type) == false)
                _components[type] = new BonusDamage<T>(0, 0);

            BonusDamage<T> currentBonusDamage = (BonusDamage<T>)_components[type];

            _components[type] = new BonusDamage<T>(currentBonusDamage.Min + bonusDamage.Min, currentBonusDamage.Max + bonusDamage.Max);
        }

        public BonusDamage<T> GetDamage<T>() where T : IDamageType
        {
            Type type = typeof(T);
            if (_components.ContainsKey(type) == false)
                return new BonusDamage<T>(0, 0);

            return (BonusDamage<T>)_components[type];
        }

        public void ApplyToAll(Action<IDamageType> action)
        {
            foreach (var component in _components.Values)
            {
                component.ApplyTo(action);
            }
        }
    }
}