using Interface;
using Items.ItemComponent;
using Items.WeaponComponent;
using Items.WeaponComponent.DamageType;
using Parameters;
using PlayerScripts.ParametersComponents;
using PlayerScripts.PlayerComponent.Resistrs;

namespace ComponentVisitor
{
    public interface IComponentVisitor
    {
        void Visit<T>(Damage<T> component) where T : IDamageType;
        void Visit<T>(ItemDescription<T> component) where T : IItemDescription;
        void Visit<T>(ItemPrice<T> component) where T : IItemPrice;
        void Visit(ItemName component);
        void Visit<T>(Parameter<T> component) where T : IParameterType;
        void Visit<T>(Resist<T> component) where T : IResistType;
    }
}