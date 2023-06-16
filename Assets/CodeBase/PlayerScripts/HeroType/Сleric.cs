using HealthPoint;
using ManaPoint;
using PlayerScripts.ParametersComponents.Components;
using PlayerScripts.PlayerComponent.Resistrs;

namespace PlayerScripts.HeroType
{
    public class Сleric : Hero
    {
        private readonly Mana<StrengthOfSpirit> _mana;

        public Сleric(Health health, Resists resists, ParametersComponents.Parameters parameters) : base(health, resists, parameters)
        {
            _mana = new Mana<StrengthOfSpirit>(this);
        }
    }
}