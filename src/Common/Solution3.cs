using System;
using Newtonsoft.Json;

namespace Common
{
    public static class Solution3
    {
        public static string SerializeNodes(Node root) => JsonConvert.SerializeObject(root);
        public static Node DeserializeNodes(this string json) => JsonConvert.DeserializeObject<Node>(json);
    }
}