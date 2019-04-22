using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public class BinaryNode
    {
        public BinaryNode(string value, BinaryNode left = null, BinaryNode right = null, string name = "Root")
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
            this.Name = name;
        }
        public string Value { get; set; }
        
        public string Name { get; set; }
        private BinaryNode left;
        private BinaryNode right;
        public BinaryNode Left
        {
            get => left;
            set
            {
                if (value != null)
                {
                    left = value;
                    left.Name = this.Name + ".Left";
                }
            }
        }
        public BinaryNode Right
        {
            get => right;
            set
            {
                if (value != null)
                {
                    right = value;
                    right.Name = this.Name + ".Right";
                }
            }
        }
        public IEnumerable<BinaryNode> Children()
        {
            if (Left != null) { yield return Left; }
            if (Right != null) { yield return Right; }
        }
    }
}