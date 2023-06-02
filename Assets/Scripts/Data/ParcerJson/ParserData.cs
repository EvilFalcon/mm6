using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Data.ParcerJson
{
    public class ParserData
    {
        public readonly ItemData[] _itemsDatas;
        public readonly SpellItemsData[] _spellItemsDatas;
        public readonly SpawnerDataInfo[] _spawnerDatas;
        public readonly MonstersData[] _monstersData;
        private Dictionary<Type, string> _pathJasons;

        public ParserData()
        {
            _pathJasons = new Dictionary<Type, string>()
            {
                { typeof(ItemData), @"Assets\Scripts\Data\Json\Items.json" },
                { typeof(SpawnerDataInfo), @"Assets\Scripts\Data\Json\RNDITEMS.json" },
                { typeof(SpellItemsData), @"Assets\Scripts\Data\Json\SPCITEMS.json" },
                { typeof(MonstersData), @"Assets\Scripts\Data\Json\Monsters.json" },
            };

            _itemsDatas = FromJson<ItemData>(typeof(ItemData));
            _spellItemsDatas = FromJson<SpellItemsData>(typeof(SpellItemsData));
            _spawnerDatas = FromJson<SpawnerDataInfo>(typeof(SpawnerDataInfo));
            _monstersData = FromJson<MonstersData>(typeof(MonstersData));
            Debug.Log($"парсер {_spawnerDatas.Length}");
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