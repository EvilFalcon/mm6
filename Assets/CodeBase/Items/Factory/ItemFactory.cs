using Data.ParcerJson;
using Data.Utils;
using UnityEngine;

namespace Items.Factory
{
    public class ItemFactory
    {
        private readonly ItemComponentBuilder _itemComponentBuilder;

        public ItemFactory(ItemComponentBuilder itemComponentBuilder)
        {
            _itemComponentBuilder = itemComponentBuilder;
        }

        public IInitializableItem CreateUnknownItem(ItemData itemData, int level)
        {
            IInitializableItem item = CreateItem(itemData);

            if (item == null)
            {
                return null;
            }

            item.AddDefaultComponent(_itemComponentBuilder.Build(itemData, level), itemData, level);
            return item;
        }

        private IInitializableItem CreateBijouterie()
        {
            return new GameObject().AddComponent<Item>();
        }

        private IInitializableItem CreateArmor()
        {
            return new GameObject().AddComponent<Item>();
        }

        private IInitializableItem CreateWeapon(ItemData itemData)
        {
            if (itemData.SkillGroup == "Bow")
            {
                return new GameObject().AddComponent<Item>();
            }

            if (itemData.SkillGroup == "Blaster")
            {
                return new GameObject().AddComponent<Item>();//Todo:
            }

            return new GameObject().AddComponent<Item>();
        }

        private IInitializableItem CreateItem(ItemData itemData)
        {
            IInitializableItem item = new GameObject().AddComponent<Item>(); //ToDO: уходит Null из за книг и бутылок !!! Сделать методы Создания

            if (ItemType.TryGetWeapon(itemData))
            {
                item = CreateWeapon(itemData);
            }

            if (ItemType.TryGetArmor(itemData))
            {
                item = CreateArmor();
            }

            if (ItemType.TryGetBijouterie(itemData))
            {
                item = CreateBijouterie();
            }

            return item;
        }
    }
}