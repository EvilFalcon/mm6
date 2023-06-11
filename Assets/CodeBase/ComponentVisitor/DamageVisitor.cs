using System;
using System.Collections.Generic;
using Items.ItemComponent.WeaponComponent;
using Items.ItemComponent.WeaponComponent.DamageType;

namespace ComponentVisitor
{
    public class DamageVisitor : AbstractVisitor
    {
        private readonly Dictionary<Type, IDamage> _components = new Dictionary<Type, IDamage>(); 
        //TODO: сделай возврат значений урона (DamageModified,DefaultDamage) 

        public override void Visit<T>(BonusDamage<T> bonusDamage)
        {
            Type type = typeof(T);

            if (_components.ContainsKey(type) == false)
                _components[type] = new BonusDamage<T>(0);

            BonusDamage<T> currentBonusDamage = (BonusDamage<T>)_components[type];

            _components[type] = new BonusDamage<T>(currentBonusDamage.Value + bonusDamage.Value);
        }

        public override void Visit<T>(DefaultDamage<T> defaultDamage)
        {
            Type type = typeof(T);

            if (_components.ContainsKey(type) == false)
                _components[type] = new DefaultDamage<T>(0, 0, 0);

            DefaultDamage<T> currentBonusDamage = (DefaultDamage<T>)_components[type];

            _components[type] = new DefaultDamage<T>
            (
                currentBonusDamage.DiceCount + defaultDamage.DiceCount,
                currentBonusDamage.SideCount + defaultDamage.SideCount,
                currentBonusDamage.Mod2 + defaultDamage.Mod2
            );
        }

        public override void Visit<T>(DamageModified<T> component)
        {
            Type type = typeof(T);

            if (_components.ContainsKey(type) == false)
                _components[type] = new DamageModified<T>(0, 0);

            DamageModified<T> currentBonusDamage = (DamageModified<T>)_components[type];

            _components[type] = new DamageModified<T>
            (
                currentBonusDamage.Min + component.Min,
                currentBonusDamage.Max + component.Max
            );
        }

        public BonusDamage<T> GetDamage<T>() where T : IDamageType
        {
            Type type = typeof(T);
            if (_components.ContainsKey(type) == false)
                return new BonusDamage<T>(0);

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