using System;
using System.Linq;

namespace Common
{
    public static class Solution11
    {
        public static string[] AutoComplete(string[] list, string input)
        {
            return list.Where(s => s.StartsWith(input)).ToArray();
        }
        public static string[] OverEngineeredAutoComplete() { throw new NotImplementedException(); }
    }
}