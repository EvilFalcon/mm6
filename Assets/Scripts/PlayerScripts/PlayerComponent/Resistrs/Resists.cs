using System.Collections.Generic;
using ComponentVisitor;
using Interface;
using PlayerScripts.PlayerComponent.Resistrs.ResistsType;

namespace PlayerScripts.PlayerComponent.Resistrs
{
    public class Resists : IComponent
    {
        private List<IResists> _component;

        public Resists(int physical, int fiery, int cold, int electric, int magic, int poison)
        {
            _component = new List<IResists>()
            {
                new Resist<PhysicalResist>(physical),
                new Resist<FieryResiet>(fiery),
                new Resist<ColdResist>(cold),
                new Resist<ElectricResist>(electric),
                new Resist<MagicResist>(magic),
                new Resist<PoisonResist>(poison),
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