using System.Collections.Generic;
using System.Linq;
using Data.ParcerJson;
using Data.Utils;
using Interface;
using Items.ItemComponent.ItemComponentInfo;
using Items.RingItem;
using Items.WeaponComponent;
using PlayerScripts.PlayerComponent.Resistrs;
using Physical = Items.WeaponComponent.DamageType.Physical;

namespace Items.ItemComponent.FactoryItem
{
    public class ItemComponentBuilder
    {
        private readonly DamageConverter _converter = new DamageConverter();
        private readonly ItemOfFactory _itemOfFactory = new ItemOfFactory();

        private readonly IReadOnlyList<string> _damage = new List<string>()
        {
            "Weapon", "Weapon2", "Weapon1or2", "Missile"
            //"Sword", "Dagger", "Axe", "Spear", "Bow", "Mace", "Club", "Staff", "Blaster"
        };

        private readonly IReadOnlyList<string> _armor = new List<string>()
        {
            "Armor", "Shield", "Helm", "Belt", "Cloak", "Gauntlets", "Boots"
            // "Leather", "Chain", "Plate", "Shield"
        };

        private readonly IReadOnlyList<string> _bijouterie = new List<string>() //TODO: сделать классы под каждый спэл
        {
            "Ring", "Amulet"
        };

        public IItem Build(ItemData itemData)
        {
            IComponent[] components;

            if (itemData.SkillGroup == null)
                return null;

            if (_damage.Contains(itemData.EquipStat))
            {
                components = GetWeaponComponents(itemData);
                //AddItemComponent(components, abstractItem);
            }

            if (_armor.Contains(itemData.EquipStat))
            {
                components = GetArmorComponents(itemData);
               // AddItemComponent(components, abstractItem);
            }

            if (_bijouterie.Contains(itemData.EquipStat))
            {
                Ring abstractItem = _itemOfFactory.CreateRing();
                components = GetBijouterieComponents(itemData);
                return AddItemComponent(components, abstractItem);
            }

            return null;
        }

        private IItem AddItemComponent<T>(IComponent[] components, T item) where T : IItem
        {
            foreach (var component in components)
            {
                item.AddComponent(component);
            }

            return item;
        }

        private IComponent[] GetWeaponComponents(ItemData itemData)
        {
            (int min, int max) = _converter.Convert(itemData.Mod1);

            return new IComponent[]
            {
                new BonusDamage<Physical>(min, max + itemData.Mod2),
                new ItemName(itemData.Name, 1),
                new ItemDescription(itemData.Notes),
                new ItemPrice<DefaultPrice>(itemData.Value, 0)
            };
        }

        private IComponent[] GetArmorComponents(ItemData itemData)
        {
            return new IComponent[]
            {
                new Resist<Physical>(int.Parse(itemData.Mod1) + itemData.Mod2),
                new ItemName(itemData.Name, 1),
                new ItemDescription(itemData.Notes),
                new ItemPrice<DefaultPrice>(itemData.Value, 0)
            };
        }

        private IComponent[] GetBijouterieComponents(ItemData itemData)
        {
            return new IComponent[]
            {
                new ItemName(itemData.Name, 1),
                new ItemDescription(itemData.Notes),
                new ItemPrice<DefaultPrice>(itemData.Value, 0)
            };
        }
    }
}