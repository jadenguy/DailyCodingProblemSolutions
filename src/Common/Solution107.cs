using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;

namespace Common
{
    public static class Solution107
    {
        public static string PrintTree<T>(BinaryNode<T> node)
        {
            var levels = GenerateStrata(node);
            return GenerateStrings(levels, node);
        }

        private static string GenerateStrings<T>(Dictionary<BinaryNode<T>, int> levels, BinaryNode<T> root)
        {
            var maxHeight = levels.Values.Max() + 1;
            var ret = new string[maxHeight * 2];
            var orderedArray = root.InOrder().ToArray();
            int length = orderedArray.Length;
            for (int column = 0; column < length; column++)
            {
                var node = orderedArray[column];
                var height = levels[node];
                var text = "[" + node.Value.ToString() + "]";
                var width = text.Length;
                const string columnSpace = " ";
                var blankCell = new string(' ', width);
                var leftSlash = node.IsLeft ? @"/" : columnSpace;
                var rightSlash = node.IsRight ? @"\" : columnSpace;
                for (int row = 0; row < maxHeight; row++)
                {
                    var slashRow = row * 2;
                    var dataRow = slashRow + 1;
                    if (column > 0)
                    {
                        ret[slashRow] += (row == height ? rightSlash : columnSpace);
                        ret[dataRow] += columnSpace;
                    }
                    if (true)
                    {
                        ret[slashRow] += (blankCell);
                        ret[dataRow] += (row == height ? text : blankCell);
                    }
                    if (column < length - 1)
                    {
                        ret[slashRow] += (row == height ? leftSlash : columnSpace);
                        ret[dataRow] += columnSpace;
                    }
                }
            }
            return ret.Print();
        }
        private static Dictionary<BinaryNode<T>, int> GenerateStrata<T>(this BinaryNode<T> node)
        {
            var levels = new Dictionary<int, List<BinaryNode<T>>>() { };
            levels.Add(0, new List<BinaryNode<T>>() { node });
            for (int i = 0; i < levels.Count; i++)
            {
                var current = levels[i];
                var nextChildrenCount = current.Where(n => n != null).SelectMany(n => n?.Children()).Count();
                if (nextChildrenCount > 0)
                {
                    var nextLevel = new List<BinaryNode<T>>();
                    foreach (var next in current)
                    {
                        nextLevel.Add(next?.Left);
                        nextLevel.Add(next?.Right);
                    }
                    levels.Add(i + 1, nextLevel);
                }
            }
            return levels.SelectMany(l => l.Value?.Select(k => new { Key = k, Value = l.Key })).Where(k => k.Key != null).ToDictionary(k => k.Key, v => v.Value);
        }
    }
}