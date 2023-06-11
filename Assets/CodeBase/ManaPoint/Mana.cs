using UnityEngine;

namespace ManaPoint
{
    public class Mana
    {
        public Mana(int value)
        {
            Max = value;
            Value = Max;
        }

        public int Max { get; private set; }
        public int Value { get; private set; }
        public int Min { get; private set; } = 0;

        public void PointRegenereit(int value)
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