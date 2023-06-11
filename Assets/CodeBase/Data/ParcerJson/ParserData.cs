using System;
using System.Collections.Generic;
using System.IO;
using Infrastructure.AssetManagement;
using UnityEngine;

namespace Data.ParcerJson
{
    public class ParserData
    {
        public readonly ItemData[] ItemsDatas;
        public readonly SpecialBonusStatData[] SpellItemsDatas;
        public readonly SpawnerDataInfo[] SpawnerDatas;
        public readonly MonstersData[] MonstersData;
        public readonly StandardBonusStatsData[] StandardBonusStats;
        private Dictionary<Type, string> _pathJasons;

        public ParserData()
        {
            _pathJasons = new Dictionary<Type, string>()
            {
                { typeof(ItemData), @"Assets\CodeBase\Data\Json\Items.json" },
                { typeof(SpawnerDataInfo), @"Assets\CodeBase\Data\Json\RNDITEMS.json" },
                { typeof(SpecialBonusStatData), @"Assets\CodeBase\Data\Json\SpecialBonus.json" },
                { typeof(MonstersData), @"Assets\CodeBase\Data\Json\Monsters.json" },
                { typeof(StandardBonusStatsData), @"Assets\CodeBase\Data\Json\StandardBonusStats.json" },
            };

            ItemsDatas = FromJson<ItemData>(typeof(ItemData));
            SpellItemsDatas = FromJson<SpecialBonusStatData>(typeof(SpecialBonusStatData));
            SpawnerDatas = FromJson<SpawnerDataInfo>(typeof(SpawnerDataInfo));
            MonstersData = FromJson<MonstersData>(typeof(MonstersData));
            StandardBonusStats = FromJson<StandardBonusStatsData>(typeof(StandardBonusStatsData));
            Program.Run();
        }

        public T[] FromJson<T>(Type type)
        {
            string json = File.ReadAllText(_pathJasons[type]);
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}