using Unity.Mathematics;

namespace Utils
{
    public class Dice
    {
        private static Random s_random;
        
        public static int GetValueDice(int diceCount, int sideCount)
        {
            int sum = 0;
            
            for (int i = 0; i < diceCount; i++)
            {
                sum = s_random.NextInt(sideCount + 1);
            }

            return sum;
        }
    }
}