using HealthPoint;
using ManaPoint;
using PlayerScripts.ParametersComponents.Components;
using PlayerScripts.PlayerComponent.Resistrs;

namespace PlayerScripts.HeroType
{
    public class Paladin : Hero
    {
        private readonly Mana<StrengthOfSpirit> _mana;

        public Paladin(Health health, Resists resists, ParametersComponents.Parameters parameters) : base(health, resists, parameters)
        {
            _mana = new Mana<StrengthOfSpirit>(this);
        }
    }
}