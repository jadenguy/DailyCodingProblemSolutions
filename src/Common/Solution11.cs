using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution11
    {
        public static string[] AutoComplete(string[] list, string input)
        {
            return list.Where(s => s.StartsWith(input)).ToArray();
        }
        public static string[] OverEngineeredTreeAutoComplete(string[] list, string input)
        {
            var ret = new List<string>();
            var tree = list.ToTree();
            ret = tree.FindLeavesAtBranch(input);
            return ret.ToArray();
        }
        public static CharArrayNode ToTree(this string[] list)
        {
            var ret = new CharArrayNode(null, null);
            CharArrayNode currentNode;
            foreach (string value in list)
            {
                currentNode = ret;
                var charArray = value.ToCharArray();
                foreach (var character in charArray)
                {
                    currentNode.AddNextLetter(character);
                    currentNode = currentNode[character];
                }
                currentNode.WordEndsHere = true;
            }
            return ret;
        }
        public static List<string> FindLeavesAtBranch(this CharArrayNode tree, string input)
        {
            var ret = new List<string>();
            var currentNode = tree;
            int i = 0;
            while (i < input.Length && currentNode.ContainsKey(input[i]))
            {
                currentNode = currentNode[input[i]];
                i++;
            }
            if (i == input.Length)
            {
                ret = GetAllLeavesBelow(currentNode);
            }
            return ret;
        }
        public static List<string> GetAllLeavesBelow(this CharArrayNode node)
        {
            var ret = new List<string>();
            if (node.WordEndsHere) { ret.Add(node.Word); }
            foreach (var item in node.Values)
            {
                foreach (var word in item.GetAllLeavesBelow())
                {
                    ret.Add(word);
                }
            }
            return ret;
        }
    }
}