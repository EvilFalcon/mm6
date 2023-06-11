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
        public string _picApSprite;

        public int ID { get; private set; }
        public int Level { get; private set; }
        public string SkillGroup { get; private set; }
        public string EquipStat { get; private set; }
        
        public string Name => GetName();
        public SpriteRenderer Image { get; private set; }
        public string DefaultSprite { get; private set; }
        
        private void Awake()
        {
            Image = GetComponent<SpriteRenderer>();
        }

        public void AddComponent(СompositeComponent component)
        {
            _components.Add(component);
        }

        public void AddDefaultComponent(СompositeComponent baseComponents, ItemData itemData, int level)
        {
            ID = itemData.ItemID;
            _picApSprite = itemData.PicFile;
            // DefaultSprite = defaultSprite;
            EquipStat = itemData.EquipStat;
            SkillGroup = itemData.SkillGroup;
            Level = level;
            _components.Add(baseComponents);
            Sprite sprite = Resources.Load<Sprite>(_picApSprite);
            Image.sprite = sprite;
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

        public void Accept(IComponentVisitor visitor)
        {
            foreach (IComponent component in _components)
            {
                component.Accept(visitor);
            }
        }
    }
}