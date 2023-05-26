using System;
using Interface;

namespace Items.Filter
{
    public class ComponentFilter
    {
        private readonly Type[] _whiteList;

        public ComponentFilter(Type[] whiteList)
        {
            _whiteList = whiteList;
        }

        public bool CheckConformity(IComponent component)
        {
            Type componentType = component.GetType();

            foreach (var type in _whiteList)
            {
                if (componentType == type || componentType.IsSubclassOf(type))
                {
                    return true;
                }
            }

            return false;
        }
    }
}