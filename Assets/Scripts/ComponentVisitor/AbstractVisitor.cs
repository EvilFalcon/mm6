using Interface;
using Items.ItemComponent;
using Items.WeaponItem.WeaponComponent;
using Items.WeaponItem.WeaponComponent.DamageType;
using PlayerScripts.ParametersComponents;
using PlayerScripts.PlayerComponent.Resistrs;

namespace ComponentVisitor
{
    public abstract class AbstractVisitor : IComponentVisitor
    {
        public virtual void Visit<T>(BonusDamage<T> bonusDamage) where T : IDamageType { } //TODO: не забудь сделать и продумать спавн придметов 

        public virtual void Visit(ItemDescription component) { }

        public virtual void Visit<T>(ItemPrice<T> component) where T : IItemPrice { }

        public virtual void Visit(ItemName component) { }

        public virtual void Visit<T>(Parameter<T> component) where T : IParameterType { }
        public virtual void Visit<T>(Resist<T> component) where T : IResistType { }

        public virtual void Visit<T>(DefaultDamage<T> component) where T : IDamageType { }
    }
}