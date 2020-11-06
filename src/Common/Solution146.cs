using System;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution146
    {
        public static BinaryNode<int> Prune(BinaryNode<int> input)
        {
            var list = input.BreadthFirstSearch().Reverse().ToArray();
            var withParent = list.SelectMany(p => p.Children().Select(c => (c, p)));
            foreach ((var child, var parent) in withParent)
            {
                var d = child.Direction;
            }
            return input;
            throw new NotImplementedException();
        }
    }
}