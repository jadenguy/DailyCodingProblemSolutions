// Given a dictionary of words and a string made up of those words (no spaces), return the original sentence in a list. If there is more than one possible reconstruction, return any of them. If there is no possible reconstruction, then return null.
// For example, given the set of words 'quick', 'brown', 'the', 'fox', and the string "thequickbrownfox", you should return ['the', 'quick', 'brown', 'fox'].
// Given the set of words 'bed', 'bath', 'bedbath', 'and', 'beyond', and the string "bedbathandbeyond", return either ['bed', 'bath', 'and', 'beyond] or ['bedbath', 'and', 'beyond'].

using System;
using System.Collections.Generic;

namespace Common
{
    public class Solution022

    {
        public static IEnumerable<string[]> ChopUpSourceText(string text, string[] wordList)
        {
            if (text.Length > 0)
            {
                foreach (var word in wordList)
                {
                    if (text.StartsWith(word))
                    {
                        var ret = new List<string>();
                        ret.Add(word);
                        string subtext = text.Substring(word.Length);
                        foreach (var item in ChopUpSourceText(subtext, wordList))
                        {
                            ret.AddRange(item);
                            yield return ret.ToArray();
                        }
                    }
                }
            }
            else { yield return new string[0]; }
        }
    }
}