using System;
using System.Collections.Generic;
using Items.WeaponComponent;
using Items.WeaponComponent.DamageType;

namespace ComponentVisitor
{
    public class DamageVisitor : AbstractVisitor
    {
        private readonly Dictionary<Type, IDamage> _components = new Dictionary<Type, IDamage>();

        public override void Visit<T>(Damage<T> damage)
        {
            Type type = typeof(T);

            if (_components.ContainsKey(type) == false)
                _components[type] = new Damage<T>(0, 0);

            Damage<T> currentDamage = (Damage<T>)_components[type];

            _components[type] = new Damage<T>(currentDamage.Min + damage.Min, currentDamage.Max + damage.Max);
        }

        public Damage<T> GetDamage<T>() where T : IDamageType
        {
            Type type = typeof(T);
            if (_components.ContainsKey(type) == false)
                return new Damage<T>(0, 0);

            return (Damage<T>)_components[type];
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