using System.Linq;

namespace Common
{
    public static class Solution121
    {
        public static bool PalindromeDeletionPossible(string input, int deletionMax)
        {
            var palindrome = PalindromeDelete(input);
            int v = input.Length - palindrome.Length;
            return v <= deletionMax;
        }
        public static string PalindromeDelete(string input)
        {
            if (input.Length < 2) { return input; }
            var ret = string.Empty;
            var left = input.First();
            var right = input.Last();
            string middle = input.Substring(1, input.Length - 2);
            if (left == right) { ret = left + PalindromeDelete(middle) + right; }
            else
            {
                var newLeft = PalindromeDelete(middle + right);
                var newRight = PalindromeDelete(left + middle);
                var orderedArray = (new string[] { newLeft, newRight }).OrderByDescending(x => x.Length).ThenBy(x => x).ToArray();
                ret = orderedArray.First();
            }
            return ret;
        }
    }
}