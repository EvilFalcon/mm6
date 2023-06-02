using System;
using System.Collections.Generic;
using System.Linq;
using Data.ParcerJson;
using Data.Utils;
using Items.Spawners;
using Random = UnityEngine.Random;

namespace Items.FactoryItem
{
    public class ItemInformationContent
    {
        private Dictionary<int, SpawnerDataInfo> _spawnerItems;
        private int _totalWeight;
        private int[] _keys;
        private SpawnerDataInfo[] _itemList;
        private SpawnerItemData _cache;

        public SpawnerDataInfo GenerateItem(SpawnerItemData spawnerItemData, out int level)
        {
            if (spawnerItemData is null)
            {
                level = default;
                return null;
            }

            if (_cache != spawnerItemData)
            {
                _itemList = ParcerData._spawnerDatas;

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
            return Get();
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

            _totalWeight = 0;

            foreach (SpawnerDataInfo item in _itemList)
            {
                _totalWeight += item.Chance[level - 1];
                _spawnerItems[_totalWeight] = item;
            }

            _keys = _spawnerItems.Keys.ToArray();
            Array.Sort(_keys);
        }

        private SpawnerDataInfo Get()
        {
            int randomWeight = Random.Range(1, _totalWeight + 1);

            return _spawnerItems[AgorithmContainer.FindValueInRange(_keys, randomWeight)];
        }
    }
}