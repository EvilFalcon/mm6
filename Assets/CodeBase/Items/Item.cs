using System.Collections.Generic;
using ComponentVisitor;
using Data.ParcerJson;
using Interface;
using Items.CombinedComponent;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Item : MonoBehaviour, IComponent, IInitializableItem, IUpgradeItem
    {
        private List<IComponent> _components = new List<IComponent>();

        public int ID { get; private set; }
        public int Level { get; private set; }
        public string SkillGroup { get; private set; }
        public string EquipStat { get; private set; }
        public string TypeBonus { get; private set; }
        public int BonusId { get; private set; }

        public string DefaultSpritePath { get; private set; }
        public string PicApSprite { get; private set; }
        public string Name => GetName();
        public string Description => GetDescription();
        public int Price => GetPrice();

        private void Awake()
        {
        }

        public void AddComponent(CompositeComponent component, string typeBonus, int bonusId)
        {
            TypeBonus = typeBonus;
            BonusId = bonusId;
            _components.Add(component);
        }

        public void AddDefaultComponent(CompositeComponent baseComponents, ItemData itemData, int level)
        {
            ID = itemData.ItemID;
            PicApSprite = itemData.PicFile;
            // DefaultSprite = defaultSprite;
            EquipStat = itemData.EquipStat;
            SkillGroup = itemData.SkillGroup;
            Level = level;
            _components.Add(baseComponents);
        }

        private string GetName()
        {
            ItemNameVisitor itemNameVisitor = new ItemNameVisitor();

            foreach (var component in _components)
            {
                component.Accept(itemNameVisitor);
            }

            return itemNameVisitor.GetNameItem();
        }

        private string GetDescription()
        {
            DescriptionVisitor visitor = new DescriptionVisitor();

            foreach (var component in _components)
            {
                component.Accept(visitor);
            }

            return visitor.GetDescriptionItem();
        } 
       
        private int GetPrice()
        {
            ItemPriceVisitor visitor = new ItemPriceVisitor();

            foreach (var component in _components)
            {
                component.Accept(visitor);
            }

            return visitor.GetPrise();
        }

        public void Accept(IComponentVisitor visitor)
        {
            foreach (IComponent component in _components)
            {
                component.Accept(visitor);
            }
        }
    }
}