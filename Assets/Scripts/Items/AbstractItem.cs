﻿using System.Collections.Generic;
using ComponentVisitor;
using Interface;

namespace Items
{
    public abstract class AbstractItem : IComponent
    {
        private List<IComponent> _components = new List<IComponent>();

        public AbstractItem(string equipStat)
        {
            EquipStat = equipStat;
        }

        public string EquipStat;

        public string Name => GetName();

        protected void AddComponent(IComponent component)
        {
            _components.Add(component);
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