﻿using System.Collections.Generic;
using ComponentVisitor;
using Interface;

namespace Items.CombinedComponent
{
    public class СompositeComponent : IComponent
    {
        private readonly List<IComponent> _components;

        public СompositeComponent(IComponent[] components)
        {
            _components = new List<IComponent>(components);
        }

        public void Accept(IComponentVisitor visitor)
        {
            foreach (var component in _components)
            {
                component.Accept(visitor);
            }
        }

        public void AddComponent(IComponent[] components)
        {
            foreach (IComponent component in components)
            {
                _components.Add(component);
            }
        }
    }
}