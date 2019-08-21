using System;
using Common.Node;
using Newtonsoft.Json;

namespace Common
{
    public static class Solution003

    {
        public static string SerializeNodes(BinaryNode<string> root) => JsonConvert.SerializeObject(root);
        public static BinaryNode<string> DeserializeNodes(this string json) => JsonConvert.DeserializeObject<BinaryNode<string>>(json);
    }
}