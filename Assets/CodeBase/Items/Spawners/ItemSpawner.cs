using Data.ParcerJson;
using Items.Factory;
using UnityEngine;

namespace Items.Spawners
{
    [RequireComponent(typeof(SpawnerItemData))]
    public class ItemSpawner : MonoBehaviour
    {
        private ItemInformationContent _itemInformationContent;

        private ItemComponentBuilder _itemComponentBuilder;

        private ItemBonusParamsBuilder _itemBonusParamsBuilder; //Todo: Сделай билдер бонусных параметров
        private ItemFactory _itemFactory;
        private ItemData _itemData;
        private SpawnerItemData _spawnerItemData;
        private ParserData _parserData;
        private int _level;

        private void Awake()
        {
            _parserData = new ParserData();
            _itemInformationContent = new ItemInformationContent(_parserData);
            _itemComponentBuilder = new ItemComponentBuilder();
            _itemBonusParamsBuilder = new ItemBonusParamsBuilder(_parserData);
            _itemFactory = new ItemFactory(_itemComponentBuilder);
            _spawnerItemData = GetComponent<SpawnerItemData>();
        }

        public Item Build()
        {
            SpawnerDataInfo spawnerDataInfo = GetRandomSpawnerInfo();
            _itemData = _parserData.ItemsDatas[spawnerDataInfo.ItemID];
            IUpgradeItem item = (IUpgradeItem)_itemFactory.CreateUnknownItem(_itemData, _level);
            item = _itemBonusParamsBuilder.Build(item, _itemData);
            return (Item)item;
        }

        private SpawnerDataInfo GetRandomSpawnerInfo()
        {
            return _itemInformationContent.GenerateRandomItem(_spawnerItemData, out _level);
        }
    }
}