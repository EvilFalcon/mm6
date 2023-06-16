using HealthPoint;
using ManaPoint;
using PlayerScripts.ParametersComponents.Components;
using PlayerScripts.PlayerComponent.Resistrs;

namespace PlayerScripts.HeroType
{
    public class Mage : Hero
    {
        private readonly Mana<Intellect> _mana;

        public Mage(Health health, Resists resists, ParametersComponents.Parameters parameters) : base(health, resists, parameters)
        {
            _mana = new Mana<Intellect>(this);
        }
    }
}