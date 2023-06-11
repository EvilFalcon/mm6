using System;
using System.Collections.Generic;
using System.Linq;
using Data.Utils;

namespace AttackSystem
{
    public static class Effect
    {
        private static readonly Dictionary<int, int> s_stats;
        private static readonly int[] s_keys;

        static Effect()
        {
            s_stats = new Dictionary<int, int>()
            {
                [500] = 30,
                [400] = 25,
                [350] = 20,
                [300] = 19,
                [275] = 18,
                [250] = 17,
                [225] = 16,
                [200] = 15,
                [175] = 14,
                [150] = 13,
                [125] = 12,
                [100] = 11,
                [75] = 10,
                [50] = 9,
                [40] = 8,
                [35] = 7,
                [30] = 6,
                [25] = 5,
                [21] = 4,
                [19] = 3,
                [17] = 2,
                [15] = 1,
                [13] = 0,
                [11] = -1,
                [9] = -2,
                [7] = -3,
                [5] = -4,
                [3] = -5,
                [0] = -6,
            };

            s_keys = s_stats.Keys.ToArray();
            Array.Sort(s_keys);
        }

        public static int Get(int stat)
        {
            return s_stats[AlgorithmContainer.FindValueInRange(s_keys, stat)];
        }
    }
}