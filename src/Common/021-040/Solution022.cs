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