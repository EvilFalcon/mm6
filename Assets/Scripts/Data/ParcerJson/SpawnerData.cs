using System;
using UnityEngine;

namespace Data.ParcerJson
{
    [Serializable]
    public class SpawnerData
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

        public int ItemID => _itemID;
        public string PicFile => _picFile;
        public string EquipStat =>_equipStat;
        public string SkillGroup =>_skillGroup;
        public int ChanceByLevel_1 => _chanceByLevel_1;
        public int ChanceByLevel_2 => _chanceByLevel_2;
        public int ChanceByLevel_3 => _chanceByLevel_3;
        public int ChanceByLevel_4 => _chanceByLevel_4;
        public int ChanceByLevel_5 => _chanceByLevel_5;
        public int ChanceByLevel_6 => _chanceByLevel_6;
    }
}