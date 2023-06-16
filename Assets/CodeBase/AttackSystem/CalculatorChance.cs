using System;

namespace AttackSystem
{
    public class CalculatorChance
    {
        private static readonly Random s_random = new Random();

        public bool CanHeroHit(int monsterArmorClass, int attackHero, float distance, int skill) //значения взяты с https://grayface.github.io/ru/mm/mechanics/#Recovery-Time
        {
            int rangePenalty = 0;
            float chance;

            if (distance > 51.19)
                return false;

            if (distance >= 10.24 && distance <= 25.59)
            {
                rangePenalty = monsterArmorClass / 2;
            }
            
            else if (distance >= 25.6)
            {
                rangePenalty = monsterArmorClass + 15;
            }

            chance = (15f + attackHero * 2 + (skill * 5) - rangePenalty) / (30f + attackHero * 2 + monsterArmorClass);
            int chancePercent = (int)(chance * 100);

            int value = s_random.Next(100);

            if (chancePercent > value)
                return true;

            return false;
        }

        public bool CanMonsterHit(int monsterLevel, int heroArmorClass)
        {
            float chance;
            chance = 100 * ((5f + monsterLevel * 2) / (10f + monsterLevel * 2 + heroArmorClass));
            int chancePercent = (int)(chance * 100);

            int value = s_random.Next(100);

            if (chancePercent > value)
                return true;

            return false;
        }

        public bool CanTakeDebuffWhenHit(int monsterLevel, float factor)
        {
            float chance;
            chance = 100f * (monsterLevel * factor);
            int chancePercent = (int)(chance * 100);

            int value = s_random.Next(100);

            if (chancePercent > value)
                return true;

            return false;
        }

        public bool CanApplyHeroDebuff(int luckEffect, int otherEffect) //Other Effect зависит от дебафа
        {
            float chance;
            chance = 100 * (30 / (30f + Effect.Get(luckEffect) + otherEffect));
            int chancePercent = (int)(chance * 100);

            int value = s_random.Next(100);

            if (chancePercent > value)
                return true;

            return false;
        }

        public bool CanApplyMonsterDebuff(int monsterResilience, int monsterLevel)
        {
            float chance;
            chance = 100 * (30f + monsterResilience + monsterLevel);
            int chancePercent = (int)(chance * 100);

            int value = s_random.Next(100);

            if (chancePercent > value)
                return true;

            return false;
        }
    }
}