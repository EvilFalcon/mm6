using System;
using UnityEngine;

namespace Data.ParcerJson
{
    [Serializable]
    public class SpawnerDataInfo
    {
        [SerializeField] private int _itemID;
        [SerializeField] private string _picFile;
        [SerializeField] private string _equipStat;
        [SerializeField] private string _skillGroup;
        [SerializeField] private int _chanceByLevel_1;
        [SerializeField] private int _chanceByLevel_2;
        [SerializeField] private int _chanceByLevel_3;
        [SerializeField] private int _chanceByLevel_4;
        [SerializeField] private int _chanceByLevel_5;
        [SerializeField] private int _chanceByLevel_6;
        [SerializeField] private string _levelItem;

        public int ItemID => _itemID;
        public string PicFile => _picFile;
        public string EquipStat => _equipStat;
        public string SkillGroup => _skillGroup;
        public string LevelItem => _levelItem;

        public int[] Chance => new int[]
        {
            _chanceByLevel_1,
            _chanceByLevel_2,
            _chanceByLevel_3,
            _chanceByLevel_4,
            _chanceByLevel_5,
            _chanceByLevel_6,
        };
    }
}