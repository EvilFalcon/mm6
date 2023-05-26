using System;
using Interface;
using Items.CombinedEffectItem;
using Items.Filter;
using Items.ItemComponent;
using Items.ItemComponent.ItemComponentInfo;
using PlayerScripts.PlayerComponent.Resistrs;

namespace Items.ArmorItem
{
    public class Armor : AbstractItem, IItem
    {
        private readonly ComponentFilter _componentFilter;

        public Armor(string equipStat, IComponent[] baseComponents) : base(equipStat, baseComponents)
        {
            _componentFilter = new ComponentFilter(new[]
            {
                typeof(BaseResist),
                typeof(СompositeComponent),
                typeof(ItemDescription),
                typeof(ItemPrice<DefaultPrice>),
                typeof(ItemPrice<BonusPrice>),
                typeof(ItemName),
            });
        }

        public new void AddComponent(IComponent component)
        {
            Type componentType = component.GetType();

            if (componentType == typeof(СompositeComponent) || componentType.IsSubclassOf(typeof(СompositeComponent)))
            {
                
            }

            if (_componentFilter.CheckConformity(component))
                base.Add(component);
        }
    }
}