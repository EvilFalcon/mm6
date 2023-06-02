using System.Collections.Generic;
using System.Linq;
using Data.ParcerJson;

namespace Data.Utils
{
    public class ItemType
    {
        private static readonly IReadOnlyList<string> _weapons = new List<string>()
        {
            "Weapon", "Weapon2", "Weapon1or2", "Missile"
        };

        private static readonly IReadOnlyList<string> _armor = new List<string>()
        {
            "Armor", "Shield", "Helm", "Cloak", "Gauntlets", "Boots"
        };

        private static readonly IReadOnlyList<string> _bijouterie = new List<string>() //TODO: сделать классы под каждый спэл
        {
            "Ring", "Amulet", "Belt"
        };

        private bool _isResult;

        public static bool TryGetWeapon(ItemData itemData)
        {
            return _weapons.Contains(itemData.EquipStat);
        }

        public static bool TryGetArmor(ItemData itemData)
        {
            return _armor.Contains(itemData.EquipStat);
        }

        public static bool TryGetBijouterie(ItemData itemData)
        {
            return _bijouterie.Contains(itemData.EquipStat);
        }
    }
}