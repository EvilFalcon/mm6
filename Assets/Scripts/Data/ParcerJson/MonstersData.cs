using System;
using UnityEngine;

namespace Data.ParcerJson
{
    [Serializable]
    public class MonstersData
    {
        [SerializeField] private int _iDMonster;
        [SerializeField] private string _picture;
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private int _hP;
        [SerializeField] private int _armorClass;
        [SerializeField] private int _eXP;
        [SerializeField] private string _treasure;
        [SerializeField] private int _treasure2Persent;
        [SerializeField] private string _treasure_2IavelItem;
        [SerializeField] private int _quest;
        [SerializeField] private string _fly;
        [SerializeField] private string _move;
        [SerializeField] private string _aIType;
        [SerializeField] private int _hst;
        [SerializeField] private int _spd;
        [SerializeField] private int _rec;
        [SerializeField] private int _pref;
        [SerializeField] private int _bonus;
        [SerializeField] private string _type;
        [SerializeField] private string _damage;
        [SerializeField] private string _miss;
        [SerializeField] private int _attPercent;
        [SerializeField] private int _type2;
        [SerializeField] private int _damage2;
        [SerializeField] private int _miss2;
        [SerializeField] private int _usePercent;
        [SerializeField] private int _spellMasSkil;
        [SerializeField] private int _fire;
        [SerializeField] private int _elec;
        [SerializeField] private int _cold;
        [SerializeField] private int _pois;
        [SerializeField] private int _phys;
        [SerializeField] private int _mag;
        [SerializeField] private int _special;

        public int IDMonster => _iDMonster;
        public string Picture => _picture;
        public string Name => _name;
        public int Level => _level;
        public int HP => _hP;
        public int ArmorClass => _armorClass;
        public int EXP => _eXP;
        public string Treasure => _treasure;
        public int Treasure2Persent => _treasure2Persent;
        public string Treasure2IevelItem => _treasure_2IavelItem;
        public int Quest => _quest;
        public string Fly => _fly;
        public string Move => _move;
        public string AIType => _aIType;
        public int Hst => _hst;
        public int Spd => _spd;
        public int Rec => _rec;
        public int Pref => _pref;
        public int Bonus => _bonus;
        public string Type => _type;
        public string Damage => _damage;
        public string Miss => _miss;
        public int AttPercent => _attPercent;
        public int Type2 => _type2;
        public int Damage2 => _damage2;
        public int Miss2 => _miss2;
        public int UsePercent => _usePercent;
        public int SpellMasSkil => _spellMasSkil;
        public int Fire => _fire;
        public int Elec => _elec;
        public int Cold => _cold;
        public int Pois => _pois;
        public int Phys => _phys;
        public int Mag => _mag;
        public int Special => _special;
    }
}