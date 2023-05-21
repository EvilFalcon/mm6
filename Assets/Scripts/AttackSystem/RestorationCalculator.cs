namespace AttackSystem.AttackSystem
{
    public class RestorationCalculator
    {
        public int GetWaitingTime(int cooldownWeapons, int cooldownArmor, int cooldownShield, int skill, int speedEffect)
        {
            int effect = Effect.Get(speedEffect);

            return cooldownWeapons + cooldownArmor + cooldownShield - (1 * skill + effect);
        }
    }
}