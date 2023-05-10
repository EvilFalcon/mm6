namespace ManaPoint
{
    public class Mana
    {
        private int _min = 0;

        public Mana(int value)
        {
            Max = value;
            Value = Max;
        }
        
        public int Max { get; private set; }
        public int Value { get; private set; }

        public void PointRegenereit(int Value)
        {
            
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