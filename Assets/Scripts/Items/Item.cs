using System.Collections.Generic;
using ComponentVisitor;
using Data.ParcerJson;
using Interface;
using Items.CombinedComponent;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour, IComponent, IInitializableItem, IUpgradeItem
    {
        private List<IComponent> _components = new List<IComponent>();

        public int Level { get; private set; }

        public string EquipStat { get; private set; }

        public string SkillGroup { get; private set; }

        public string Name => GetName();

        public void AddComponent(СompositeComponent component)
        {
            _components.Add(component);
        }

        public void AddDefaultComponent(СompositeComponent baseComponents, ItemData itemData, int level)
        {
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

        public void Accept(IComponentVisitor visitor)
        {
            foreach (IComponent component in _components)
            {
                component.Accept(visitor);
            }
        }
    }
}