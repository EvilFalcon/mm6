using System;
using System.Collections.Generic;
using System.Linq;
using Data.ParcerJson;
using Data.Utils;
using Interface;
using Items.CombinedComponent;
using Items.ItemComponent;
using Items.ItemComponent.ItemComponentInfo;
using Items.ItemComponent.WeaponComponent.DamageType;
using PlayerScripts.ParametersComponents;
using PlayerScripts.ParametersComponents.Components;
using PlayerScripts.PlayerComponent.Resistrs;

namespace Items.BonusParameterFactory
{
    public class StandardParamFactory
    {
        private List<StandardBonusStatsData> _bonusStatsData;
        private readonly Dictionary<int, (int, int)> _points;
        private readonly Dictionary<int, Func<CompositeComponent>> _components;
        private int _pointsParams;
        private int _idBonus;

        public StandardParamFactory(ParserData parserData)
        {
            _bonusStatsData = parserData.StandardBonusStats.ToList();
            _points = new Dictionary<int, (int, int)>()
            {
                [2] = (1, 5),
                [3] = (3, 8),
                [4] = (6, 12),
                [5] = (10, 17),
                [6] = (15, 25),
            };

            _components = new Dictionary<int, Func<CompositeComponent>>()
            {
                [1] = CreatePower,
                [2] = CreateIntellect,
                [3] = CreateStrengthOfSpirit,
                [4] = CreateEndurance,
                [5] = CreateAccuracy,
                [6] = CreateSpeed,
                [7] = CreateLuck,
                [8] = CreateHillPointBonus,
                [9] = CreateMagicPointBonus,
                [10] = CreatePhysicalResist,
                [11] = CreateFieryResist,
                [12] = CreateElectricResist,
                [13] = CreateColdResist,
                [14] = CreatePoisonResist,
            };
        }

        public IUpgradeItem CreateRandomBonus(IUpgradeItem item)
        {
            int componentType = 0;

            switch (item.EquipStat)
            {
                case "Armor":
                    componentType = 0;
                    break;
                case "Shield":
                    componentType = 1;
                    break;
                case "Helm":
                    componentType = 2;
                    break;
                case "Cloak":
                    componentType = 3;
                    break;
                case "Gauntlets":
                    componentType = 4;
                    break;
                case "Boots":
                    componentType = 5;
                    break;
                case "Ring":
                    componentType = 6;
                    break;
                case "Amulet":
                    componentType = 7;
                    break;
                case "Belt":
                    componentType = 8;
                    break;
            }

            item.AddComponent(Create(item.Level, componentType), "Standard", _idBonus);
            return item;
        }

        private CompositeComponent Create(int level, int componentType)
        {
            SortedBonusData(componentType);
            StandardBonusStatsData standardBonusStatsData = GetRandomObject(level);
            (int min, int max) = _points[level];
            _pointsParams = AlgorithmContainer.GetRandomWeight(min, max);
            return InvokeCompositeComponentById(standardBonusStatsData.IdBonusStats);
        }

        private void SortedBonusData(int componentType)
        {
            _bonusStatsData = _bonusStatsData.Where(bonus => bonus.Armor[componentType] > 0).ToList();
        }

        private StandardBonusStatsData GetRandomObject(int level)
        {
            Dictionary<int, StandardBonusStatsData> spawnerItems = new Dictionary<int, StandardBonusStatsData>();

            int totalWeight = 0;

            foreach (var item in _bonusStatsData)
            {
                totalWeight += item.Armor[level - 1];
                spawnerItems[totalWeight] = item;
            }

            int[] keys = spawnerItems.Keys.ToArray();
            Array.Sort(keys);

            return spawnerItems[AlgorithmContainer.FindValueInRange(keys, AlgorithmContainer.GetRandomWeight(totalWeight))];
        }

        private CompositeComponent CreatePower()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Силе ", 2),
                new Parameter<Power>(_pointsParams)
            });
        }

        private CompositeComponent CreateIntellect()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Интелекту", 2),
                new Parameter<Intellect>(_pointsParams)
            });
        }

        private CompositeComponent CreateStrengthOfSpirit()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Силе Духа", 2),
                new Parameter<StrengthOfSpirit>(_pointsParams)
            });
        }

        private CompositeComponent CreateEndurance()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Выносливости", 2),
                new Parameter<Endurance>(_pointsParams)
            });
        }

        private CompositeComponent CreateAccuracy()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Меткости", 2),
                new Parameter<Accuracy>(_pointsParams)
            });
        }

        private CompositeComponent CreateSpeed()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Скорости", 2),
                new Parameter<Speed>(_pointsParams)
            });
        }

        private CompositeComponent CreateLuck()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Удаче", 2),
                new Parameter<Luck>(_pointsParams)
            });
        }

        private CompositeComponent CreateHillPointBonus()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Очкам Здоровья", 2),
                new HealthComponent(_pointsParams)
            });
        }

        private CompositeComponent CreateMagicPointBonus() //ToDo:сделать здоровье и магию
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Очкам Магии", 2),
                new ManaComponent(_pointsParams)
            });
        }

        private CompositeComponent CreatePhysicalResist()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : +{_pointsParams} к Класу Брони", 2),
                new Resist<Physical>(_pointsParams)
            });
        }

        private CompositeComponent CreateFieryResist()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое :защита от огня +{_pointsParams}", 2),
                new Resist<Fiery>(_pointsParams)
            });
        }

        private CompositeComponent CreateElectricResist()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : защита от электричества +{_pointsParams}", 2),
                new Resist<Electric>(_pointsParams)
            });
        }

        private CompositeComponent CreateColdResist()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : защита от холода +{_pointsParams}", 2),
                new Resist<Cold>(_pointsParams)
            });
        }

        private CompositeComponent CreatePoisonResist()
        {
            return new CompositeComponent(new IComponent[]
            {
                new ItemName(_bonusStatsData[1].OfName, 2),
                new ItemPrice<BonusPrice>(100 * _pointsParams, 1),
                new ItemDescription($"Особое : защита от яда  +{_pointsParams}", 2),
                new Resist<Poison>(_pointsParams)
            });
        }

        public CompositeComponent InvokeCompositeComponentById(int id, int pointBonus = default)
        {
            if (pointBonus == default)
                return null;

            _pointsParams = pointBonus;
            _idBonus = id;
            return _components[id].Invoke();
        }
    }
}