using Common.FileSystem;
using System;
using System.Collections.Generic;

namespace Common
{
    public static class Solution17
    {
        public static string LongestPath(string tree)
        {
            var ret = string.Empty;
            FileSystemObject returnObject = FilePathParser.Parse(tree);
            foreach (var item in ((Directory)returnObject).gci(true))
            {
                if (item.GetType() == typeof(File) && ret.Length < item.Path.Length) { ret = item.Path; }
            }
            return ret;
        }
    }
}