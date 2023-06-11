using System;
using Interface;
using JetBrains.Annotations;

namespace HealthPoint
{
    public class Health : IWillCure
    {
        public Health(int value)
        {
            Value = value;
            Max = Value;
        }
        
        [CanBeNull] public event Action Died;

        public int Max { get; private set; }
        public int Value { get; private set; }
        public int Min { get; } = 0;

        public void IncreaseHealth(int points)
        {
            Max += points;
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

            if (Value < Min)
                Value = Min;

            if (Value == Min)
                Died?.Invoke();
        }
    }
}