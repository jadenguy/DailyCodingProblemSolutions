using System;

namespace Common
{
    public class Solution46
    {
        public static string FindLongestAnagram(string text)
        {
            var longestPalindrome = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = longestPalindrome.Length; j < text.Length - i; j++)
                {
                    // System.Diagnostics.Debug.WriteLine(i);
                    // System.Diagnostics.Debug.WriteLine(j);
                    string subString = text.Substring(i, j);
                    if (IsPalindrome(subString))
                    {
                        longestPalindrome = subString;
                    }
                }
            }
            return longestPalindrome;
        }
        public static bool IsPalindrome(string text)
        {
            var ret = true;
            int i = 0;
            while (ret && i < text.Length / 2)
            {
                char v = text[i];
                char v1 = text[text.Length - i - 1];
                System.Diagnostics.Debug.WriteLine($"{v} {v1}");
                if (v != v1)
                {
                    ret = false;
                }
                i++;
            }
            return ret;
        }
    }
}