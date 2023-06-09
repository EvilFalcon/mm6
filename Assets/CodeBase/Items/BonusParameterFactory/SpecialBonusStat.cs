﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Data.ParcerJson;
using Data.Utils;
using Interface;
using Items.CombinedComponent;
using Items.ItemComponent;
using Items.ItemComponent.ItemComponentInfo;
using Items.ItemComponent.WeaponComponent;
using Items.ItemComponent.WeaponComponent.DamageType;
using PlayerScripts.ParametersComponents;
using PlayerScripts.ParametersComponents.Components;
using PlayerScripts.PlayerComponent.Resistrs;
using Unity.VisualScripting;

namespace Items.BonusParameterFactory
{
    public class SpecialBonusStat
    {
        private Dictionary<int, CompositeComponent> _components;
        private SpecialBonusStatData[] _bonusStatDatas;
        private List<int> _price;
        private SpecialBonusStatData[] _specialBonus;
        private Dictionary<int, SpecialBonusStatData> _spawnerItems = new Dictionary<int, SpecialBonusStatData>();
        private int _totalWeight;
        private int[] _keys;
        private int _id;

        public SpecialBonusStat(ParserData data)
        {
            _bonusStatDatas = data.SpellItemsDatas;
            _components = new Dictionary<int, CompositeComponent>()
            {
                [1] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[1].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[1].Value, 1),
                    new ItemDescription(_bonusStatDatas[1].Description, 2),
                    new Resist<Fiery>(10),
                    new Resist<Cold>(10),
                    new Resist<Poison>(10),
                    new Resist<Electric>(10),
                }),
                [2] = new CompositeComponent(new IComponent[]
                { 
                    new ItemName(_bonusStatDatas[2].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[2].Value, 1),
                    new ItemDescription(_bonusStatDatas[2].Description, 2),
                    new Parameter<Accuracy>(10),
                    new Parameter<Endurance>(10),
                    new Parameter<Intellect>(10),
                    new Parameter<Power>(10),
                    new Parameter<StrengthOfSpirit>(10),
                    new Parameter<Speed>(10),
                    new Parameter<Luck>(10),
                }),
                [3] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[3].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[3].Value, 1),
                    new ItemDescription(_bonusStatDatas[3].Description, 2),
                    //ToDo: снарядные удары (радиус огн.шара, урон=повр.оруж.)
                }),
                [4] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[4].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[4].Value, 1),
                    new ItemDescription(_bonusStatDatas[4].Description, 2),
                    new DamageModified<Cold>(3, 4)
                }),
                [5] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[5].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[5].Value, 1),
                    new ItemDescription(_bonusStatDatas[5].Description, 2),
                    new DamageModified<Cold>(6, 8)
                }),
                [6] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[6].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[6].Value, 1),
                    new ItemDescription(_bonusStatDatas[6].Description, 2),
                    new DamageModified<Cold>(9, 12)
                }),
                [7] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[7].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[7].Value, 1),
                    new ItemDescription(_bonusStatDatas[7].Description, 2),
                    new DamageModified<Electric>(2, 5)
                }),
                [8] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[8].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[8].Value, 1),
                    new ItemDescription(_bonusStatDatas[8].Description, 2),
                    new DamageModified<Electric>(4, 10)
                }),
                [9] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[9].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[9].Value, 1),
                    new ItemDescription(_bonusStatDatas[9].Description, 2),
                    new DamageModified<Electric>(6, 15)
                }),
                [10] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[10].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[10].Value, 1),
                    new ItemDescription(_bonusStatDatas[10].Description, 2),
                    new DamageModified<Fiery>(1, 6)
                }),
                [11] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[11].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[11].Value, 1),
                    new ItemDescription(_bonusStatDatas[11].Description, 2),
                    new DamageModified<Fiery>(2, 12)
                }),
                [12] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[12].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[12].Value, 1),
                    new ItemDescription(_bonusStatDatas[12].Description, 2),
                    new DamageModified<Fiery>(3, 18)
                }),
                [13] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[13].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[13].Value, 1),
                    new ItemDescription(_bonusStatDatas[13].Description, 2),
                    new BonusDamage<Poison>(5)
                }),
                [14] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[14].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[14].Value, 1),
                    new ItemDescription(_bonusStatDatas[14].Description, 2),
                    new BonusDamage<Poison>(8)
                }),
                [15] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[15].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[15].Value, 1),
                    new ItemDescription(_bonusStatDatas[15].Description, 2),
                    new BonusDamage<Poison>(12)
                }),
                [16] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[16].NameAdd, 2),
                    new ItemPrice<BonusPrice>(0, 2),
                    new ItemDescription(_bonusStatDatas[16].Description, 2),
                }),
                [17] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[17].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[17].Value, 1),
                    new ItemDescription(_bonusStatDatas[17].Description, 2),
                }),
                [18] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[18].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[18].Value, 1),
                    new ItemDescription(_bonusStatDatas[18].Description, 2),
                }),
                [19] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[19].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[19].Value, 1),
                    new ItemDescription(_bonusStatDatas[19].Description, 2),
                }),
                [20] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[20].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[20].Value, 1),
                    new ItemDescription(_bonusStatDatas[20].Description, 2),
                }),
                [21] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[21].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[21].Value, 1),
                    new ItemDescription(_bonusStatDatas[21].Description, 2),
                }),
                [22] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[22].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[22].Value, 1),
                    new ItemDescription(_bonusStatDatas[22].Description, 2),
                }),
                [23] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[23].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[23].Value, 1),
                    new ItemDescription(_bonusStatDatas[23].Description, 2),
                }),
                [24] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[24].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[24].Value, 1),
                    new ItemDescription(_bonusStatDatas[24].Description, 2),
                }),
                [25] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[25].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[25].Value, 1),
                    new ItemDescription(_bonusStatDatas[25].Description, 2),
                }),
                [26] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[26].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[26].Value, 1),
                    new ItemDescription(_bonusStatDatas[26].Description, 2),
                }),
                [27] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[27].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[27].Value, 1),
                    new ItemDescription(_bonusStatDatas[27].Description, 2),
                }),
                [28] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[28].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[28].Value, 1),
                    new ItemDescription(_bonusStatDatas[28].Description, 2),
                }),
                [29] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[29].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[29].Value, 1),
                    new ItemDescription(_bonusStatDatas[29].Description, 2),
                }),
                [30] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[30].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[30].Value, 1),
                    new ItemDescription(_bonusStatDatas[30].Description, 2),
                }),
                [31] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[31].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[31].Value, 1),
                    new ItemDescription(_bonusStatDatas[31].Description, 2),
                }),
                [32] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[32].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[32].Value, 1),
                    new ItemDescription(_bonusStatDatas[32].Description, 2),
                }),
                [33] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[33].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[33].Value, 1),
                    new ItemDescription(_bonusStatDatas[33].Description, 2),
                }),
                [34] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[34].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[34].Value, 1),
                    new ItemDescription(_bonusStatDatas[34].Description, 2),
                }),
                [35] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[35].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[35].Value, 1),
                    new ItemDescription(_bonusStatDatas[35].Description, 2),
                }),
                [36] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[36].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[36].Value, 1),
                    new ItemDescription(_bonusStatDatas[36].Description, 2),
                }),
                [37] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[37].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[37].Value, 1),
                    new ItemDescription(_bonusStatDatas[37].Description, 2),
                }),
                [38] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[38].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[38].Value, 1),
                    new ItemDescription(_bonusStatDatas[38].Description, 2),
                }),
                [39] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[39].NameAdd, 2),
                    new ItemPrice<BonusPrice>(0, 2),
                    new ItemDescription(_bonusStatDatas[39].Description, 2),
                }),
                [40] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[40].NameAdd, 2),
                    new ItemPrice<BonusPrice>(0, 2),
                    new ItemDescription(_bonusStatDatas[40].Description, 2),
                }),
                [41] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[41].NameAdd, 2),
                    new ItemPrice<BonusPrice>(0, 3),
                    new ItemDescription(_bonusStatDatas[41].Description, 2),
                }),
                [42] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[42].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[42].Value, 1),
                    new ItemDescription(_bonusStatDatas[42].Description, 2),
                    new Parameter<Accuracy>(1),
                    new Parameter<Endurance>(1),
                    new Parameter<Intellect>(1),
                    new Parameter<Power>(1),
                    new Parameter<Luck>(1),
                    new Parameter<Speed>(1),
                    new Parameter<StrengthOfSpirit>(1),
                    new Resist<Physical>(1),
                    new Resist<Cold>(1),
                    new Resist<Electric>(1),
                    new Resist<Fiery>(1),
                    new Resist<Poison>(1),
                    new HealthComponent(1),
                    new ManaComponent(1)
                }),
                [43] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[43].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[43].Value, 1),
                    new ItemDescription(_bonusStatDatas[43].Description, 2),
                    new Parameter<Endurance>(10),
                    new Resist<Physical>(10),
                    new HealthComponent(10),
                }),
                [44] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[44].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[44].Value, 1),
                    new ItemDescription(_bonusStatDatas[44].Description, 2),
                    new HealthComponent(10),
                }),
                [45] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[45].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[45].Value, 1),
                    new ItemDescription(_bonusStatDatas[45].Description, 2),
                    new Parameter<Speed>(5),
                    new Parameter<Accuracy>(5),
                }),
                [46] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[46].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[46].Value, 1),
                    new ItemDescription(_bonusStatDatas[46].Description, 2),
                    new Parameter<Power>(25),
                    new DamageModified<Fiery>(10, 20)
                }),
                [47] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[47].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[47].Value, 1),
                    new ItemDescription(_bonusStatDatas[47].Description, 2),
                    new ManaComponent(10),
                }),
                [48] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[48].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[48].Value, 1),
                    new ItemDescription(_bonusStatDatas[48].Description, 2),
                    new Parameter<Endurance>(15),
                    new Resist<Physical>(5),
                }),
                [49] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[49].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[49].Value, 1),
                    new ItemDescription(_bonusStatDatas[49].Description, 2),
                    new Parameter<Luck>(10),
                    new Parameter<Intellect>(10),
                }),
                [50] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[50].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[50].Value, 1),
                    new ItemDescription(_bonusStatDatas[50].Description, 2),
                    new Resist<Fiery>(30),
                }),
                [51] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[51].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[51].Value, 1),
                    new ItemDescription(_bonusStatDatas[51].Description, 2),
                    new ManaComponent(10),
                    new Parameter<Speed>(10),
                    new Parameter<Intellect>(10),
                }),
                [52] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[52].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[52].Value, 1),
                    new ItemDescription(_bonusStatDatas[52].Description, 2),
                    new Parameter<Endurance>(10),
                    new Parameter<Accuracy>(10),
                }),
                [53] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[53].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[53].Value, 1),
                    new ItemDescription(_bonusStatDatas[53].Description, 2),
                    new Parameter<Power>(10),
                    new Parameter<StrengthOfSpirit>(10),
                }),
                [54] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[54].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[54].Value, 1),
                    new ItemDescription(_bonusStatDatas[54].Description, 2),
                    new Parameter<Endurance>(15),
                }),
                [55] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[55].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[55].Value, 1),
                    new ItemDescription(_bonusStatDatas[55].Description, 2),
                    new Parameter<Luck>(15),
                }),
                [56] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[56].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[56].Value, 1),
                    new ItemDescription(_bonusStatDatas[56].Description, 2),
                    new Parameter<Power>(5),
                    new Parameter<Endurance>(5),
                }),
                [57] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[57].NameAdd, 2),
                    new ItemPrice<BonusPrice>(_bonusStatDatas[57].Value, 1),
                    new ItemDescription(_bonusStatDatas[57].Description, 2),
                    new Parameter<Intellect>(5),
                    new Parameter<StrengthOfSpirit>(5),
                }),
                [58] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[58].NameAdd, 2),
                    new ItemPrice<BonusPrice>(0, 10),
                    new ItemDescription(_bonusStatDatas[58].Description, 2),
                }),
                [59] = new CompositeComponent(new IComponent[]
                {
                    new ItemName(_bonusStatDatas[59].NameAdd, 2),
                    new ItemPrice<BonusPrice>(0, 2),
                    new ItemDescription(_bonusStatDatas[59].Description, 2),
                }),
            };
        }

        public IUpgradeItem Create(IUpgradeItem item)
        {
            if (_totalWeight > 0)
            {
                _spawnerItems.Clear();
                _price.Clear();
                _totalWeight = 0;
            }

            Group group = GetGroup(item.Level);
            SortedSpecialBonus(group, item.EquipStat);
            CompositeComponent component = _components[GetRandomComponent().IdSpecialBonus];
            item.AddComponent(component, "Special", _id);

            return item;
        }

        private Group GetGroup(int level)
        {
            switch (level)
            {
                case 3:
                    return Group.A | Group.B;

                case 4:
                    return Group.A | Group.B | Group.C;

                case 5:
                    return Group.B | Group.C | Group.D;

                case 6:
                    return Group.D;
            }

            return Group.None;
        }

        private void SortedSpecialBonus(Group group, string equipStat)
        {
            _bonusStatDatas.AddRange(_specialBonus
                .Where(bonus => group.ToString().Contains(bonus.LevelItem) && HasPrivateField(bonus, equipStat))
                .ToList());
        }

        private bool HasPrivateField(SpecialBonusStatData data, string fieldName)
        {
            var field = data
                .GetType()
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (field == null)
                return false;

            if ((int)field.GetValue(data) > 0)
            {
                _price.Add((int)field.GetValue(data) + _price[^1]);
                AddValidEntity(data, (int)field.GetValue(data));
                return true;
            }

            return false;
        }

        private void AddValidEntity(SpecialBonusStatData specialBonusStatData, int prise)
        {
            _totalWeight += prise;
            _spawnerItems[_totalWeight] = specialBonusStatData;

            _keys = _spawnerItems.Keys.ToArray();
            Array.Sort(_keys);
        }

        private SpecialBonusStatData GetRandomComponent()
        {
            _id = AlgorithmContainer.FindValueInRange(_keys, AlgorithmContainer.GetRandomWeight(_totalWeight));

            return _spawnerItems[_id];
        }
    }

    [Flags]
    enum Group : byte
    {
        None = 0,
        A = 1,
        B = 2,
        C = 4,
        D = 8,
    }
}