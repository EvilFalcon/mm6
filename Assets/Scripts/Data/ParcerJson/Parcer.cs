using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Data.ParcerJson
{
    public class Parcer : MonoBehaviour
    {
        private static ItemData[] _itemsDatas;
        private static SpellItemsData[] _spellItemsDatas;
        private static SpawnerData[] _spawnerDatas;
        private static MonstersData[] _monstersData;
        private static Dictionary<Type, string> _pathJasons;

        private void Awake()
        {
            _pathJasons = new Dictionary<Type, string>()
            {
                { typeof(ItemData), @"Assets\Scripts\Data\Json\Items.json" },
                { typeof(SpawnerData), @"Assets\Scripts\Data\Json\RNDITEMS.json" },
                { typeof(SpellItemsData), @"Assets\Scripts\Data\Json\SPCITEMS.json" },
                { typeof(MonstersData), @"Assets\Scripts\Data\Json\Monsters.json" },
            };

            _itemsDatas = FromJson<ItemData>(typeof(ItemData));
            _spellItemsDatas = FromJson<SpellItemsData>(typeof(SpellItemsData));
            _spawnerDatas = FromJson<SpawnerData>(typeof(SpawnerData));
            _monstersData = FromJson<MonstersData>(typeof(MonstersData));
        }

        public static T[] FromJson<T>(Type type)
        {
            string json = File.ReadAllText(_pathJasons[type]);
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
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