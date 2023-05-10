using System;

namespace AttackSystem
{
    public class DamageCalculator
    {
        public float Calculate(float damage, int luck, float sustainability)
        {


            if (sustainability <= 0)
                return damage;

            float chance = 1 - 30 / (30 + sustainability + Effect.Get(luck));
            int chancePercent = (int)(chance * 100);

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int value = random.Next(100);

                if (chancePercent > value)
                {
                    return damage;
                }

                damage /= 2;
            }

            return damage;
        }
    }
}