using Data.ParcerJson;
using Data.Utils;
using Items.ArmorItem;
using Items.CombinedComponent;
using Items.WeaponItem;
using UnityEngine;

namespace Items.FactoryItem
{
    public class ItemFactory
    {
        public IItem CreateUnknownItem(ItemData itemData, int level)
        {
            if (ItemType.TryGetWeapon(itemData))
            {
                return CreateWeapon(itemData, level);
            }

            if (ItemType.TryGetArmor(itemData))
            {
                return CreateArmor(itemData, level);
            }

            if (ItemType.TryGetBijouterie(itemData))
            {
                return CreateBijouterie(itemData, level);
            }

            return default;
        }

        public IItem CreateBijouterie(ItemData itemData, int level)
        {
            Bijouterie.Bijouterie bijouterie = new GameObject().AddComponent<Bijouterie.Bijouterie>();

            return bijouterie;
        }

        public IItem CreateArmor(ItemData itemData, int level)
        {
            Armor armor = new GameObject().AddComponent<Armor>();
           
            return armor;
        }

        public IItem CreateWeapon(ItemData itemData, int level)
        {
            if (itemData.SkillGroup == "Bow")
            {
                Bow bow = new GameObject().AddComponent<Bow>();

                return bow;
            }

            if (itemData.SkillGroup == "Blaster")
            {
                Blaster blaster = new GameObject().AddComponent<Blaster>();
               
                return blaster;
            }

            Weapon weapon = new GameObject().AddComponent<Weapon>();
            return weapon;
        }
    }
}