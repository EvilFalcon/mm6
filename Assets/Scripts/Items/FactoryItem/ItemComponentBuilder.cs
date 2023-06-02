using Data.ParcerJson;
using Data.Utils;
using Interface;
using Items.CombinedComponent;
using Items.ItemComponent;
using Items.ItemComponent.ItemComponentInfo;
using Items.WeaponItem.WeaponComponent;
using Items.WeaponItem.WeaponComponent.DamageType;
using PlayerScripts.PlayerComponent.Resistrs;
using Utils;

namespace Items.FactoryItem
{
    public class ItemComponentBuilder
    {
        private readonly DamageConverter _converter = new DamageConverter();

        public СompositeComponent Build(ItemData itemData, int level)
        {
            if (itemData.SkillGroup == null)
                return null;

            СompositeComponent components = new СompositeComponent(new IComponent[]
            {
                new ItemName(itemData.Name, 1),
                new ItemDescription(itemData.Notes),
                new ItemPrice<DefaultPrice>(itemData.Value, 0)
            });

            if (ItemType.TryGetWeapon(itemData))
            {
                return CreateComponentWeapon(itemData, components);
            }

            if (ItemType.TryGetArmor(itemData))
            {
                return CreateComponentArmor(itemData, components);
            }

            if (ItemType.TryGetBijouterie(itemData))
            {
                return components;
            }

            return null;
        }

        private СompositeComponent CreateComponentArmor(ItemData itemData, СompositeComponent components)
        {
            components.AddComponent(new IComponent[]
            {
                new Resist<Physical>(int.Parse(itemData.Mod1) + itemData.Mod2)
            });

            return components;
        }

        private СompositeComponent CreateComponentWeapon(ItemData itemData, СompositeComponent components)
        {
            (int min, int max) = _converter.Convert(itemData.Mod1);

            components.AddComponent(new IComponent[]
            {
                new DefaultDamage<Physical>(min, max, itemData.Mod2),
            });

            return components;
        }
    }
}