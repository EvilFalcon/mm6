using System;
using System.Collections.Generic;
using System.Linq;
using Data.ParcerJson;
using Data.Utils;
using Items.Spawners;

namespace Items.Factory
{
    public class ItemInformationContent
    {
        private int _totalWeight;
        private int[] _keys;
        private SpawnerDataInfo[] _itemList;
        private SpawnerItemData _cache;
        private ParserData _parserData;

        public ItemInformationContent(ParserData data)
        {
            _parserData = data;
        }

        public SpawnerDataInfo GenerateRandomItem(SpawnerItemData spawnerItemData, out int level)
        {
            if (spawnerItemData is null)
            {
                level = default;
                return null;
            }

            if (_cache != spawnerItemData)
            {
                _itemList = _parserData.SpawnerDatas;

                _cache = spawnerItemData;

                if (String.IsNullOrEmpty(spawnerItemData.SkillGroup) == false)
                {
                    SortingByItemType(spawnerItemData.SkillGroup);
                }

                if (String.IsNullOrEmpty(spawnerItemData.EquipStat) == false)
                {
                    SortByCategoryType(spawnerItemData.EquipStat);
                }

                SortingBySpawnerLevel(spawnerItemData.Level);
            }

            level = spawnerItemData.Level;
            return GetRandomObject(level);
        }

        private void SortByCategoryType(string equipStat)
        {
            _itemList = _itemList.Where(item => item.EquipStat == equipStat).ToArray();
        }

        private void SortingByItemType(string skillGroup)
        {
            _itemList = _itemList.Where(item => item.SkillGroup == skillGroup).ToArray();
        }

        private void SortingBySpawnerLevel(int level)
        {
            _itemList = _itemList
                .Where(spawnerData => spawnerData.Chance[level - 1] > 0)
                .ToArray();
        }
        
        private SpawnerDataInfo GetRandomObject(int level)
        {
            Dictionary<int, SpawnerDataInfo> spawnerItems = new Dictionary<int, SpawnerDataInfo>();

            int totalWeight = 0;

            foreach (var item in _itemList)
            {
                totalWeight += item.Chance[level - 1];
                spawnerItems[totalWeight] = item;
            }

            int[] keys = spawnerItems.Keys.ToArray();
            Array.Sort(keys);

            return spawnerItems[AlgorithmContainer.FindValueInRange(keys, AlgorithmContainer.GetRandomWeight(totalWeight))];
        }
    }
}