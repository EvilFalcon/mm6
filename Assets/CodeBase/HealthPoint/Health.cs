using System;
using AttackSystem;
using ComponentVisitor;
using Interface;
using JetBrains.Annotations;
using PlayerScripts.ParametersComponents.Components;

namespace HealthPoint
{
    public class Health : IWillCure
    {
        private readonly IComponent _component;

        public Health(IComponent component)
        {
            _component = component;
            Value = Max;
        }

        [CanBeNull] public event Action Died;

        public int Max => GetMaxHealth();
        public int Value { get; private set; }
        private int _thresholdOfDeath;
        private int _min;

        private int GetMaxHealth()
        {
            HealthVisitor healthVisitor = new HealthVisitor();
            ParameterVisitorType<Endurance> enduranceVisitor = new ParameterVisitorType<Endurance>();
            _component.Accept(healthVisitor);
            _component.Accept(enduranceVisitor);
            _thresholdOfDeath = enduranceVisitor.Value;

            if (_thresholdOfDeath > 0)
                _thresholdOfDeath *= -1;

            return healthVisitor.Health + Effect.Get(enduranceVisitor.Value);
        }

        public void Heal(int points)
        {
            if (points <= 0)
                return;

            Value += points;

            if (Value > Max)
                Value = Max;
        }

        public void TakeDamage(int attack)
        {
            if (attack <= 0)
                return;

            Value -= attack;

            if (Value < _thresholdOfDeath)
                Value = _thresholdOfDeath;

            if (Value == _thresholdOfDeath)
                Died?.Invoke();
        }
    }
}