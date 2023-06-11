using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data.ParcerJson
{
    [Serializable]
    public class SpawnerDataInfo
    {
        [SerializeField] private int _itemID;
        [SerializeField] private string _picFile;
        [SerializeField] private string _equipStat;
        [SerializeField] private string _skillGroup;
        [SerializeField] private int _chanceByLevel1;
        [SerializeField] private int _chanceByLevel2;
        [SerializeField] private int _chanceByLevel3;
        [SerializeField] private int _chanceByLevel4;
        [SerializeField] private int _chanceByLevel5;
        [SerializeField] private int _chanceByLevel6;
        [SerializeField] private string _levelItem;

        public int ItemID => _itemID;
        public string PicFile => _picFile;
        public string EquipStat => _equipStat;
        public string SkillGroup => _skillGroup;
        public string LevelItem => _levelItem;

        public int[] Chance => new int[]
        {
            _chanceByLevel1,
            _chanceByLevel2,
            _chanceByLevel3,
            _chanceByLevel4,
            _chanceByLevel5,
            _chanceByLevel6,
        };
    }
}