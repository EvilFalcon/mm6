using Interface;
using UnityEngine;

namespace ManaPoint
{
    public abstract class AbstractMana
    {
        protected readonly IComponent Component;

        public AbstractMana(IComponent component)
        {
            Component = component;
            Value = Max;
        }

        public int Max => GetMaxManaPoint();
        public int Value { get; private set; }
        public int Min { get; private set; } = 0;
        
        protected virtual int GetMaxManaPoint() => default;
        
        protected void PointRegenereit(int value)
        {
            if (Value < 0)
                return;

            Value = Mathf.Clamp(Value + value, Min, Max);
        }
        
        public bool TryUseMagicSpell(int cost)
        {
            if (cost > Value)
                return false;

            Value -= cost;
            return true;
        }
    }
}