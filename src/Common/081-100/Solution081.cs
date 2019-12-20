using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution081
    {
        public static IEnumerable<string> FindPossibilities(Dictionary<char, char[]> dict, string v)
        {
            var first = v.First();
            var rest = string.Join("", v.Skip(1));
            char[] possibilities = dict[first];
            if (v.Length > 1) { return possibilities.SelectMany(l => FindPossibilities(dict, rest).Select(r => l + r)); }
            else { return possibilities.Select(r => r.ToString()); }
        }
    }
}