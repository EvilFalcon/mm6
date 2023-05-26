using System.Collections.Generic;
using System.Linq;
using ComponentVisitor;
using Interface;
using Items.Filter;

namespace Items.CombinedEffectItem
{
    public abstract class СompositeComponent : IComponent
    {
        private readonly IComponent[] _components;

        public СompositeComponent(IEnumerable<IComponent> components)
        {
            _components = components.ToArray();
        }

        public void Accept(IComponentVisitor visitor)
        {
            foreach (var component in _components)
            {
                component.Accept(visitor);
            }
        }

        public bool CheckConformity(ComponentFilter componentFilter)
        {
            foreach (var component in _components)
            {
                if (componentFilter.CheckConformity(component) == false)
                    return false;
            }

            return true;
        }
    }
}