using System.Collections.Generic;
using ComponentVisitor;
using Interface;
using Items.CombinedComponent;
using UnityEngine;

namespace Items
{
    public abstract class AbstractItem : MonoBehaviour, IComponent
    {
        private List<IComponent> _components = new List<IComponent>();

        public int Level;

        public string EquipStat;

        public string SkillGroup;

        public string Name => GetName();

        protected void Add(IComponent component)
        {
            _components.Add(component);
        }

        protected void AddDefaultParams(СompositeComponent baseComponents, string equipStat, string skillGroup, int level)
        {
            EquipStat = equipStat;
            SkillGroup = skillGroup;
            Level = level;
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