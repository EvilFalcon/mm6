using System;
using UnityEngine;

namespace Data.ParcerJson
{
    [Serializable]
    public class SpecialBonusStatData
    {
        [SerializeField] private int _idSpecialBonus;
        [SerializeField] private string _specialBonusesByGroup;
        [SerializeField] private string _nameAdd;
        [SerializeField] private int _weapon;
        [SerializeField] private int _missile;
        [SerializeField] private int _armor;
        [SerializeField] private int _shield;
        [SerializeField] private int _helm;
        [SerializeField] private int _belt;
        [SerializeField] private int _cloak;
        [SerializeField] private int _gauntlets;
        [SerializeField] private int _boots;
        [SerializeField] private int _ring;
        [SerializeField] private int _amulet;
        [SerializeField] private int _value;
        [SerializeField] private string _levelItem;
        [SerializeField] private string _description;

        public int IdSpecialBonus => _idSpecialBonus;
        public string SpecialBonusesByGroup => _specialBonusesByGroup;
        public string NameAdd => _nameAdd;
        public int Weapon => _weapon;
        public int Missile => _missile;
        public int Armor => _armor;
        public int Shield => _shield;
        public int Helm => _helm;
        public int Belt => _belt;
        public int Cloak => _cloak;
        public int Gauntlets => _gauntlets;
        public int Boots => _boots;
        public int Ring => _ring;
        public int Amulet => _amulet;
        public int Value => _value;
        public string LevelItem => _levelItem;
        public string Description => _description;
    }
}