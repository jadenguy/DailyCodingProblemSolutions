using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution096
    {
        public static int[][] Permutations(int[] number)
        {
            return number.EveryPermutation().ToArray();
        }
    }
}