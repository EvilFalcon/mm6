using System.Collections.Generic;
using ComponentVisitor;
using Interface;
using UnityEngine;

namespace Items.WeaponItem
{
    public class Sword : MonoBehaviour, IWeapon, IComponent
    {
        private List<IComponent> _components = new List<IComponent>();

        public string Name => GetName();

        public void AddComponent(IComponent component)
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