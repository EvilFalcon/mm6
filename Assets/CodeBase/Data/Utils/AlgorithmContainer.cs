using Random = UnityEngine.Random;

namespace Data.Utils
{
    public static class AlgorithmContainer
    {
        public static int GetRandomWeight(int value) =>
            Random.Range(1, value + 1);
        
        public static int GetRandomWeight(int min, int max) =>
            Random.Range(min, max + 1);

        public static int FindValueInRange(int[] valueCollection, int value)
        {
            int low = 0;
            int high = valueCollection.Length - 1;
            int guess;

            if (valueCollection[valueCollection.Length - 1] <= value)
            {
                return valueCollection[valueCollection.Length - 1];
            }

            if (valueCollection[low] > value)
            {
                return valueCollection[low];
            }

            while (low <= high)
            {
                guess = (low + high) / 2;

                if (valueCollection[guess] <= value && valueCollection[guess + 1] > value)
                {
                    return valueCollection[guess];
                }

                if (valueCollection[guess] > value)
                {
                    high = guess - 1;
                }
                else
                {
                    low = guess + 1;
                }
            }

            return low;
        }
    }
}