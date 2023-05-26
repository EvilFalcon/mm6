using Interface;
using Items.CombinedEffectItem;
using Items.Filter;
using Items.ItemComponent;
using Items.ItemComponent.ItemComponentInfo;
using Items.WeaponComponent;
using Items.WeaponComponent.DamageType;

namespace Items.WeaponItem
{
    public class Weapon : AbstractItem, IItem
    {
        private readonly ComponentFilter _componentFilter;

        public Weapon(string equipStat, IComponent[] baseComponents) : base(equipStat, baseComponents)
        {
            _componentFilter = new ComponentFilter(new[]
            {
                typeof(BonusDamage<PoisonDamage>),
                typeof(BonusDamage<Cold>),
                typeof(BonusDamage<Fiery>),
                typeof(СompositeComponent),
                typeof(ItemPrice<BonusPrice>),
                typeof(ItemName),
            });
        }

        public new void AddComponent(IComponent component)
        {
            if (_componentFilter.CheckConformity(component))
                Add(component);
        }
    }
}