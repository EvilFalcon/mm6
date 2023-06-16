using System.Collections.Generic;
using ComponentVisitor;
using Interface;
using Items.ItemComponent.WeaponComponent.DamageType;

namespace PlayerScripts.PlayerComponent.Resistrs
{
    public class Resists : IComponent
    {
        private List<IResists> _component;

        public Resists(int physical, int fiery, int cold, int electric, int magic, int poison)
        {
            _component = new List<IResists>()
            {
                new Resist<Physical>(physical),
                new Resist<Fiery>(fiery),
                new Resist<Cold>(cold),
                new Resist<Electric>(electric),
                new Resist<Magic>(magic),
                new Resist<Poison>(poison),
            };
        }

        public void Accept(IComponentVisitor visitor)
        {
            foreach (var component in _component)
            {
                component.Accept(visitor);
            }
        }
    }
}