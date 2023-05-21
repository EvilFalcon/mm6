using System.Collections.Generic;
using System.Linq;
using ComponentVisitor;
using Interface;

namespace Items.CombinedEffectItem
{
    public class СompositeComponent : IComponent
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
    }
}