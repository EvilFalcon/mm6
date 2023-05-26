using Interface;
using Items.CombinedEffectItem;
using Items.Filter;
using Items.ItemComponent;
using Items.ItemComponent.ItemComponentInfo;
using PlayerScripts.PlayerComponent.Resistrs;

namespace Items.RingItem
{
    public class Ring : AbstractItem, IItem
    {
        private ComponentFilter _componentFilter;

        public Ring(string equipStat, IComponent[] baseComponents) : base(equipStat, baseComponents)
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
            if (_componentFilter.CheckConformity(component))
                base.Add(component);
        }
    }
}