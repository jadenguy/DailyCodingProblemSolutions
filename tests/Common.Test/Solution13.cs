using System;
using System.Collections.Generic;
using Common.Node;

namespace Common
{
    public class Solution13
    {
        public static string SubSpecial(string sourceString, int maxUniqueCharacters)
        {
            var ret = string.Empty;
            int searchSpace = sourceString.Length;
            int i = 0;
            while (i < searchSpace)
            {
                var usedChar = new List<char>(maxUniqueCharacters);
                var keepLooking = true;
                int j = 0;
                while (j < sourceString.Length - i && keepLooking)
                {
                    char letter = sourceString[i + j];
                    System.Diagnostics.Debug.WriteLine($"{i} {j} {letter} {sourceString.Substring(i, j + 1)}");
                    if (!usedChar.Contains(letter))
                    {
                        if (usedChar.Count < maxUniqueCharacters) { usedChar.Add(letter); j++; }
                        else { keepLooking = false; }
                    }
                    else { j++; }
                    if (j > ret.Length) { ret = sourceString.Substring(i, j); }
                }
                searchSpace = sourceString.Length - ret.Length;
                i++;
            }
            return ret;
        }
    }
}