using System.Linq;

namespace Common
{
    public static class Solution118
    {
        public static int[] OrderedSquares(int[] input)
        {
            return input.Select(n => n * n).OrderBy(n => n).ToArray();
        }
    }
}