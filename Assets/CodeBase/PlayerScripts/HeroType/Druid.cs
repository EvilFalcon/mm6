using HealthPoint;
using ManaPoint;
using PlayerScripts.ParametersComponents.Components;
using PlayerScripts.PlayerComponent.Resistrs;

namespace PlayerScripts.HeroType
{
    public class Druid : Hero
    {
        private readonly ManaDoobleType<Intellect, StrengthOfSpirit> _mana;

        public Druid(Health health, Resists resists, ParametersComponents.Parameters parameters) : base(health, resists, parameters)
        {
            _mana = new ManaDoobleType<Intellect, StrengthOfSpirit>(this);
        }
    }
}