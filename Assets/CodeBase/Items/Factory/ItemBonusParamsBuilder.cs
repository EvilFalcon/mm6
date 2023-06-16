using Data.ParcerJson;
using Data.Utils;
using Items.BonusParameterFactory;

namespace Items.Factory
{
    public class ItemBonusParamsBuilder
    {
        private string _levelItem;
        private StandardParamFactory _standardParamsFactory;
        private SpecialBonusStat _specialBonusStat;
        private readonly int[] _chanceStandardParam;
        private readonly int[] _chanceSpecialParam;
        private readonly int[] _chanceWeaponSpecialParam;
        private bool _isWeapon;

        public ItemBonusParamsBuilder(ParserData parserData)
        {
            _standardParamsFactory = new StandardParamFactory(parserData);

            _chanceStandardParam = new[]
            {
                0, 40, 40, 40, 40, 75,
            };
            _chanceSpecialParam = new[]
            {
                0, 0, 10, 15, 20, 25,
            };
            _chanceWeaponSpecialParam = new[]
            {
                0, 0, 10, 20, 30, 50,
            };
        }

        public IUpgradeItem Build(IUpgradeItem item)
        {
            if (item.Level < 2 || ItemType.TryGetWeapon(item.EquipStat) && item.Level < 3)
                return item;

            return GiveNewProperties(item);
        }

        private IUpgradeItem GiveNewProperties(IUpgradeItem item)
        {
            if (ItemType.TryGetWeapon(item.EquipStat) && TryGetChance(_chanceWeaponSpecialParam[item.Level - 1]))
                return _specialBonusStat.Create(item);

            if (TryGetChance(_chanceSpecialParam[item.Level]))
                return _specialBonusStat.Create(item);

            if (TryGetChance(_chanceStandardParam[item.Level]))
                return _standardParamsFactory.CreateRandomBonus(item);

            return item;
        }

        private bool TryGetChance(int chance)
        {
            int percent = AlgorithmContainer.GetRandomWeight(0, 100);

            return chance >= percent;
        }
    }
}