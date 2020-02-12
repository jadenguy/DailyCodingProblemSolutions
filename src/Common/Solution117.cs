using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution117
    {
        public static int MinimumSum(BinaryNode<int> node)
        {
            if (node is null) { throw new System.ArgumentNullException(nameof(node)); }
            var strats = new List<BinaryNode<int>[]>() { new BinaryNode<int>[] { node } };
            bool keepGoing = true;
            for (int i = 0; keepGoing; i++)
            {
                var current = strats[i];
                var item = current.SelectMany(n => n.Children()).ToArray();
                if (item.Length == 0) { keepGoing = false; }
                else { strats.Add(item); }
            }
            var orderedEnumerable = Enumerable.Range(0, strats.Count).Select(i => new { level = i, sum = strats[i].Sum(n => n.Value) }).OrderBy(s => s.sum).ThenBy(l => l.level);
            var winnerStrats = orderedEnumerable.FirstOrDefault();
            var stratsSum = winnerStrats.level;
            return stratsSum;
        }
    }
}