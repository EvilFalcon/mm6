using System;

namespace Utils
{
    public class DamageConverter
    {
        public (int Min, int Max) Convert(string dice)
        {
            dice = dice.Trim().ToLower();
            string[] split = dice.Split('d');

            if (split.Length != 2)
                throw new ArgumentException();

            int dices = int.Parse(split[0]);
            int sides = int.Parse(split[1]);

            return (dices, sides * dices);
        }
    }
}