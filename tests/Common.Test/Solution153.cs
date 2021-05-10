// Find an efficient algorithm to find the smallest distance (measured in number of words) between any two given words in a string.
// For example, given words "hello", and "world" and a text content of "dog cat hello cat dog dog hello cat world", return 1 because there's only one word "cat" in between the two words.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Test
{
    internal class Solution153
    {
        internal static int ShortestDistanceBetweenWords(string str, string word1, string word2)
        {
            var words = Tokenize(str).ToArray();
            var table = BuildTable(words);
            var n = table.OrderBy(k => k.Key).ToArray();
            return table[GetTuple(word1, word2)];
        }
        private static Dictionary<(string, string), int> BuildTable(string[] words)
        {
            var ret = new Dictionary<(string, string), int>();
            var lastSeen = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];
                foreach (var otherWord in lastSeen.Keys)
                {
                    var distance = i - lastSeen[otherWord];
                    var pair = GetTuple(currentWord, otherWord);
                    bool wasFound = ret.TryGetValue(pair, out var known);
                    known = wasFound ? known : int.MaxValue;
                    ret[pair] = Math.Min(known, distance);
                }
                lastSeen[currentWord] = i;
            }
            return ret;
        }

        private static (string, string) GetTuple(string v1, string v2)
        {
            return v1.CompareTo(v2) < 0 ? (v1, v2) : (v2, v1);
        }

        private static IEnumerable<string> Tokenize(string str)
        {
            var wordStart = 0;
            int length = str.Length;
            for (int i = 0; i < length; i++)
            {
                if (str[i] == ' ')
                {
                    yield return (str.Substring(wordStart, i - wordStart));
                    wordStart = i + 1;
                }
            }
            yield return (str.Substring(wordStart, length - wordStart));
        }
    }
}