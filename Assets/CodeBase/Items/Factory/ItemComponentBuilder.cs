using Data.ParcerJson;
using Data.Utils;
using Interface;
using Items.CombinedComponent;
using Items.ItemComponent;
using Items.ItemComponent.ItemComponentInfo;
using Items.ItemComponent.WeaponComponent;
using Items.ItemComponent.WeaponComponent.DamageType;
using PlayerScripts.PlayerComponent.Resistrs;

namespace Items.Factory
{
    public class ItemComponentBuilder
    {
        private readonly DamageConverter _converter = new DamageConverter();

        public CompositeComponent Build(ItemData itemData, int level)
        {
            if (itemData.SkillGroup == null)
                return null;

            CompositeComponent components = new CompositeComponent(new IComponent[]
            {
                new ItemName(itemData.Name, 1),
                new ItemDescription(itemData.Notes, 1),
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

        private CompositeComponent CreateComponentArmor(ItemData itemData, CompositeComponent components)
        {
            components.AddComponent(new IComponent[]
            {
                new Resist<Physical>(int.Parse(itemData.Mod1) + itemData.Mod2)
            });

            return components;
        }

        private CompositeComponent CreateComponentWeapon(ItemData itemData, CompositeComponent components)
        {
            (int min, int max) = _converter.Convert(itemData.Mod1);

            if (itemData.SkillGroup != "Blaster")
            {
                components.AddComponent(new IComponent[]
                {
                    new DefaultDamage<Physical>(min, max, itemData.Mod2),
                });
                
                return components;
            }

            components.AddComponent(new IComponent[]
            {
                new DefaultDamage<Energy>(min, max, itemData.Mod2)
            });

            return components;
        }
    }
}