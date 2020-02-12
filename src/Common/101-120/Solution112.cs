using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution112
    {
        public static BinaryNode<T> FindLowestCommonAncestor<T>(BinaryNode<T> root, BinaryNode<T> a, BinaryNode<T> b)
        {
            var iRangeIncludingParent = root.InOrder().ToArray().SelectRangeIncluding(a, b).ToArray();
            var bRangeIncludingParent = root.BreadthFirstSearch().Reverse().SkipWhile(n => !(a.Equals(n) || b.Equals(n))).Reverse();
            return bRangeIncludingParent.Where(n => iRangeIncludingParent.Contains(n)).FirstOrDefault();
        }
        private static IEnumerable<T> SelectRangeIncluding<T>(this IEnumerable<T> array, T a, T b)
        {
            int indexA = array.Find(a);
            int indexB = array.Find(b);
            int indexSkip = Math.Min(indexA, indexB);
            int countTake = Math.Max(indexA, indexB) - indexSkip + 1;
            return array.Skip(indexSkip).Take(countTake);
        }
        private static int Find<T>(this IEnumerable<T> array, T element) => Enumerable.Range(0, array.Count()).Where(i => array.ElementAt(i).Equals(element))?.First() ?? -1;
    }
}