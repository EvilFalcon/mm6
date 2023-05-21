using Interface;
using Items.ItemComponent;
using Items.WeaponComponent;
using Items.WeaponComponent.DamageType;
using Parameters;
using PlayerScripts.ParametersComponents;
using PlayerScripts.PlayerComponent.Resistrs;

namespace ComponentVisitor
{
    public abstract class AbstractVisitor : IComponentVisitor
    {
        public virtual void Visit<T>(Damage<T> damage) where T : IDamageType { } //TODO: не забудь сделать и продумать спавн придметов 

        public virtual void Visit<T>(ItemDescription<T> component) where T : IItemDescription { }

        public virtual void Visit<T>(ItemPrice<T> component) where T : IItemPrice { }

        public virtual void Visit(ItemName component) { }

        public virtual void Visit<T>(Parameter<T> component) where T : IParameterType { }
        public virtual void Visit<T>(Resist<T> component) where T : IResistType { }
    }
}