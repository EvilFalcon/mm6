using System.Collections.Generic;
using System.Linq;
using Data.ParcerJson;
using Items;

namespace Data.Utils
{
    public class ItemType
    {
        private static readonly IReadOnlyList<string> s_weapons = new List<string>()
        {
            "Weapon", "Weapon2", "Weapon1or2", "Missile"
        };

        private static readonly IReadOnlyList<string> s_armor = new List<string>()
        {
            "Armor", "Shield", "Helm", "Cloak", "Gauntlets", "Boots"
        };

        private static readonly IReadOnlyList<string> s_bijouterie = new List<string>() //TODO: сделать классы под каждый спэл
        {
            "Ring", "Amulet", "Belt"
        };

        private bool _isResult;

        public static bool TryGetWeapon(ItemData itemData)
        {
            return s_weapons.Contains(itemData.EquipStat);
        }

        public static bool TryGetWeapon(string itemData)
        {
            return s_weapons.Contains(itemData);
        }

        public static bool TryGetArmor(ItemData itemData)
        {
            return s_armor.Contains(itemData.EquipStat);
        }

        public static bool TryGetArmor(string itemData)
        {
            return s_armor.Contains(itemData);
        }

        public static bool TryGetBijouterie(ItemData itemData)
        {
            return s_bijouterie.Contains(itemData.EquipStat);
        }

        public static bool TryGetBijouterie(string itemData)
        {
            return s_bijouterie.Contains(itemData);
        }
    }
}