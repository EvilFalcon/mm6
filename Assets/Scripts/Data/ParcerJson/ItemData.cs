using System;
using UnityEngine;

namespace Data.ParcerJson
{
    [Serializable]
    public class ItemData
    {
        [SerializeField] private int _itemID;
        [SerializeField] private string _picFile;
        [SerializeField] private string _name;
        [SerializeField] private int _value;
        [SerializeField] private string _equipStat;
        [SerializeField] private string _skillGroup;
        [SerializeField] private string _mod1;
        [SerializeField] private int _mod2;
        [SerializeField] private int _material;
        [SerializeField] private int _identificationRepairState;
        [SerializeField] private string _notIdentifiedName;
        [SerializeField] private int _spriteIndex;
        [SerializeField] private int _shape;
        [SerializeField] private int _equipX;
        [SerializeField] private int _equipY;
        [SerializeField] private string _notes;

        public int ItemID => _itemID;
        public string PicFile => _picFile;
        public string Name => _name;
        public int Value => _value;
        public string EquipStat => _equipStat;
        public string SkillGroup => _skillGroup;
        public string Mod1 => _mod1;
        public int Mod2 => _mod2;
        public int Material => _material;
        public int IdentificationRepairState => _identificationRepairState;
        public string NotIdentifiedName => _notIdentifiedName;
        public int SpriteIndex => _spriteIndex;
        public int Shape => _shape;
        public int EquipX => _equipX;
        public int EquipY => _equipY;
        public string Notes => _notes;
    }
}