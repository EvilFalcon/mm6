using Data.ParcerJson;
using Items.CombinedComponent;
using Items.FactoryItem;
using UnityEngine;

namespace Items.Spawners
{
    [RequireComponent(typeof(SpawnerItemData))]
    public class SpawnerItem : MonoBehaviour
    {
        private ItemInformationContent _itemInformationContent;

        private ItemComponentBuilder _itemComponentBuilder;

        private ItemBonusParamsBuilder _itemBonusParamsBuilder; //Todo: Сделай билдер бонусных параметров
        private ItemFactory _itemFactory;
        private ItemData _itemData;
        private SpawnerItemData _spawnerItemData;
        private int _level;

        private void Awake()
        {
            _itemInformationContent = new ItemInformationContent();
            _itemComponentBuilder = new ItemComponentBuilder();
            _itemBonusParamsBuilder = new ItemBonusParamsBuilder();
            _itemFactory = new ItemFactory();
            _spawnerItemData = GetComponent<SpawnerItemData>();
        }

        public IItem Build()
        {
            SpawnerDataInfo spawnerDataInfo = GetSpawnerInfo();
            _itemData = ParcerData._itemsDatas[spawnerDataInfo.ItemID];
            СompositeComponent сompositeComponent = _itemComponentBuilder.Build(_itemData, _level);
            IItem item = _itemFactory.CreateUnknownItem(_itemData, _level);
            item.AddDefaultComponent(сompositeComponent, _itemData.EquipStat, _itemData.SkillGroup, _level);
            return item;
        }

        private SpawnerDataInfo GetSpawnerInfo()
        {
            return _itemInformationContent.GenerateItem(_spawnerItemData, out _level);
        }
    }
}