namespace Common
{
    public class BinaryNode
    {
        public BinaryNode(string value , BinaryNode left = null, BinaryNode right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;

        }
        public string Value { get; set; }
        public BinaryNode Left { get; set; }
        public BinaryNode Right { get; set; }
    }
}