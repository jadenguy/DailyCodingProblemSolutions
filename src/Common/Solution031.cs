using System;
using System.Collections.Generic;
using System.Linq;
using Common.TextCompare;

namespace Common
{
    public static class Solution031

    {
        public static int MeasureDistance(string a, string b)
        {
            var ret = Math.Max(a.Length, b.Length);
            var matchList = new List<CharMatch>();
            for (int x = 0; x < a.Length; x++)
            {
                for (int y = 0; y < b.Length; y++)
                {
                    if (a[x] == b[y])
                    {
                        matchList.Add(new CharMatch(a[x], x, y));
                    }
                }
            }
            var chains = GenerateChains(matchList);
            int longestChain = chains.OrderByDescending(m => m.Count).FirstOrDefault().Count;
            return ret - longestChain;
        }
        private static IEnumerable<List<CharMatch>> GenerateChains(List<CharMatch> matchList)
        {
            foreach (var item in matchList)
            {
                var chain = new List<CharMatch>() { item };
                foreach (var fullChain in chain.AddLink(matchList))
                {
                    yield return fullChain;
                }
            }
        }
        static IEnumerable<List<CharMatch>> AddLink(this List<CharMatch> chain, List<CharMatch> availableLinks)
        {
            var last = chain.Last();
            var nextLinks = availableLinks.Where(x => x.LeftTextIndex > last.LeftTextIndex && x.RightTextIndex > last.RightTextIndex).ToArray();
            if (nextLinks.Length == 0) { yield return chain; }
            else
            {
                foreach (var nextLink in nextLinks)
                {
                    var newChain = new List<CharMatch>(chain) { nextLink };
                    foreach (var nextChain in newChain.AddLink(availableLinks))
                    {
                        yield return nextChain;
                    }
                }
            }
        }
        // public static int MeasureDistanceDeadEnd(string a, string b)
        // {
        //     var x = 0;
        //     var y = 0;
        //     var mostChars = Math.Max(a.Length, b.Length);
        //     var matches = 0;
        //     while (x < a.Length)
        //     {
        //         char v = a[x];
        //         char v1 = b[y];
        //         if (v == v1)
        //         {
        //             matches++;
        //             x++;
        //             y = matches;
        //         }
        //         else
        //         {
        //             y++;
        //         }
        //     }
        //     return mostChars - matches;
        // }
        // public static int MeasureDistanceOld(string a, string b)
        // {
        //     var ret = Math.Max(a.Length, b.Length);
        //     var matchList = new List<(SubString, SubString)>();
        //     foreach (var subA in a.AllSubStrings())
        //     {
        //         foreach (var subB in b.AllSubStrings())
        //         {
        //             if (subA.Text == subB.Text)
        //             {
        //                 matchList.Add((subA, subB));
        //             }
        //         }
        //     }
        //     var dict = matchList.ToDictionary(e => e, e => matchList.Where(x => x.Item1.StartCharacter >= e.Item1.StartCharacter && x.Item2.StartCharacter >= e.Item2.StartCharacter));
        //     return ret;
        // }
        // private static IEnumerable<List<(SubString, SubString)>> GetChainsRecurse(this Dictionary<(SubString, SubString), List<(SubString, SubString)>> dict, List<(SubString, SubString)> list = null)
        // {
        //     if (list == null) { list = dict.Keys.ToList(); }
        //     var outList = new List<List<(SubString, SubString)>>();
        //     foreach (var item in list)
        //     {
        //         foreach (var x in dict[item])
        //         {
        //             outList.AddRange(dict.GetChainsRecurse(list.ToList()));
        //         }
        //     }
        //     return outList;
        // }
        private static IEnumerable<SubString> AllSubStrings(this string text)
        {
            for (int start = 0; start <= text.Length; start++)
            {
                for (int length = 1; length <= text.Length - start; length++)
                {
                    var subString = text.Substring(start, length);
                    yield return new SubString(subString, start, length);
                }
            }
        }
    }
}