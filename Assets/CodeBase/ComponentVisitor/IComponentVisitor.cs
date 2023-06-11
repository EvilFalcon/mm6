using Interface;
using Items.ItemComponent;
using Items.ItemComponent.WeaponComponent;
using Items.ItemComponent.WeaponComponent.DamageType;
using PlayerScripts.ParametersComponents;
using PlayerScripts.PlayerComponent.Resistrs;

namespace ComponentVisitor
{
    public interface IComponentVisitor
    {
        void Visit<T>(BonusDamage<T> component) where T : IDamageType;
        
        void Visit(ItemDescription component);
        void Visit<T>(ItemPrice<T> component) where T : IItemPrice;
        
        void Visit(ItemName component);
        void Visit<T>(Parameter<T> component) where T : IParameterType;
        
        void Visit<T>(Resist<T> component) where T : IResistType;
        
        void Visit<T>(DefaultDamage<T> component) where T : IDamageType;
        void Visit<T>(DamageModified<T> component) where T : IDamageType;
    }
}