﻿using Interface;
using Items.ItemComponent;
using Items.ItemComponent.ItemComponentInfo;
using Items.ItemComponent.WeaponComponent;
using Items.ItemComponent.WeaponComponent.DamageType;
using PlayerScripts.ParametersComponents;
using PlayerScripts.PlayerComponent.Resistrs;

namespace ComponentVisitor
{
    public abstract class AbstractVisitor : IComponentVisitor
    {
        public virtual void Visit<T>(BonusDamage<T> bonusDamage) where T : IDamageType { }

        public virtual void Visit(ItemDescription component) { }

        public virtual void Visit<T>(ItemPrice<T> component) where T : IItemPrice { }

        public virtual void Visit(ItemName component) { }

        public virtual void Visit<T>(Parameter<T> component) where T : IParameterType { }
        
        public virtual void Visit<T>(Resist<T> component) where T : IResistType { }

        public virtual void Visit<T>(DefaultDamage<T> component) where T : IDamageType { }
        
        public virtual void Visit<T>(DamageModified<T> component) where T : IDamageType { }
        
        public virtual void Visit(HealthComponent component) { }
        
        public virtual void Visit(ManaComponent component) { }
    }
}