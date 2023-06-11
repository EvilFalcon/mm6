using Data.ParcerJson;
using Data.Utils;
using Items.BonusParameterFactory;
using Items.CombinedComponent;

namespace Items.Factory
{
    public class ItemBonusParamsBuilder
    {
        private string _levelItem;
        private StandartParametrFactory _standardParamsFactory;
        private SpecialBonusStat _specialBonusStat;
        private bool _isWeapon;

        public ItemBonusParamsBuilder(ParserData parserData)
        {
            SpecialBonusStat _specialBonusStat = new SpecialBonusStat(parserData);
            _standardParamsFactory = new StandartParametrFactory(parserData);
        }

        public IUpgradeItem Build(IUpgradeItem item, ItemData itemData)
        {
            _specialBonusStat.Create(item.Level, item.EquipStat);

            //_isWeapon = ItemType.TryGetWeapon(item);

            // if (item.Level < 2 || _isWeapon && item.Level < 3)
            //     return null;
//
            // СompositeComponent component = GiveNewProperties(item, itemData);
//
            // if (component == null)
            //     return item;
//
            // item.AddComponent(component);
            return item;
        }

        private СompositeComponent GiveNewProperties(IUpgradeItem item, ItemData itemData)
        {
            if (item.Level == 2 && _isWeapon == false)
                _standardParamsFactory.CreateRandomBonus(item.Level, item.EquipStat);

            return default;
        }

        public Item GetSpecialBonus(Item item, ItemData itemData)
        {
            return item;
        }
    }
}