using System.Collections.Generic;
using System.Linq;
using Data.ParcerJson;

namespace Items.BonusParameterFactory
{
    public class StandartParametrFactory
    {
        private readonly ParserData _parserData;
        private List<StandardBonusStatsData> _bonusStatsData;

        public StandartParametrFactory(ParserData parserData)
        {
            _parserData = parserData;
        }

        public void CreateRandomBonus(int level, string equipStat)
        {
            switch (equipStat)
            {
                case "Armor":
                    Create(level, 1);
                    break;
                case "Shield":
                    Create(level, 2);
                    break;
                case "Helm":
                    Create(level, 3);
                    break;
                case "Cloak":
                    Create(level, 4);
                    break;
                case "Gauntlets":
                    Create(level, 5);
                    break;
                case "Boots":
                    Create(level, 6);
                    break;
                case "Ring":
                    Create(level, 7);
                    break;
                case "Amulet":
                    Create(level, 8);
                    break;
                case "Belt":
                    Create(level, 9);
                    break;
            }
        }

        private void Create(int level,int componentType )
        {
            SortedBonusData(componentType);
            
        }

        private void SortedBonusData(int componentType)
        {
            _bonusStatsData = _parserData.StandardBonusStats.ToList();
            _bonusStatsData = _bonusStatsData.Where(bonus => bonus.Armor[componentType] > 0).ToList();
        }
    }
}