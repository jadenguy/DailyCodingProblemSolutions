using System;
using Common.Node;
using Newtonsoft.Json;

namespace Common
{
    public static class Solution3
    {
        public static string SerializeNodes(BinaryNode root) => JsonConvert.SerializeObject(root);
        public static BinaryNode DeserializeNodes(this string json) => JsonConvert.DeserializeObject<BinaryNode>(json);
    }
}