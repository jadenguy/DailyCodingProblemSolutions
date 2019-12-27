using Common.Node;
// using Newtonsoft.Json;
using System.Text.Json;
namespace Common
{
    public static class Solution003

    {
        public static string SerializeNodes(BinaryNode<string> root) => JsonSerializer.Serialize(root);
        // public static string NewtonSoftSerializeNodes(BinaryNode<string> root) => JsonConvert.SerializeObject(root);
        public static BinaryNode<string> DeserializeNodes(this string json) => JsonSerializer.Deserialize<BinaryNode<string>>(json);
        // public static BinaryNode<string> NewtonSoftDeserializeNodes(this string json) => JsonConvert.DeserializeObject<BinaryNode<string>>(json);
    }
}