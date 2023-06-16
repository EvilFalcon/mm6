using System;
using Interface;
using UnityEngine;

namespace Data.ParcerJson
{
    [Serializable]
    public class StandardBonusStatsData
    {
        [SerializeField] private int _idBonusStats;
        [SerializeField] private string _bonusStat;
        [SerializeField] private string _ofName;
        [SerializeField] private int _armor;
        [SerializeField] private int _shield;
        [SerializeField] private int _helm;
        [SerializeField] private int _belt;
        [SerializeField] private int _cloak;
        [SerializeField] private int _gauntlets;
        [SerializeField] private int _boots;
        [SerializeField] private int _ring;
        [SerializeField] private int _amulet;

        public int IdBonusStats => _idBonusStats;
        public string BonusStat => _bonusStat;
        public string OfName => _ofName;
        public int[] Armor => new[] { _armor, _shield, _helm, _cloak, _gauntlets, _boots, _ring, _amulet, _belt };
    }
}