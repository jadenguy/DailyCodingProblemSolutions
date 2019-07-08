using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Common.Node
{
    public class XorLinkedListMemoryDictionary : IEnumerable<XorLinkedListNode>

    {
        private IDictionary<int, XorLinkedListNode> memory;
        private Random rand;
        private XorLinkedListNode topNode;
        public XorLinkedListMemoryDictionary(string rootNodeValue = "root", int seed = 0)
        {
            if (seed == 0) { rand = new Random(); }
            else { rand = new Random(seed); }
            memory = new Dictionary<int, XorLinkedListNode>();
            topNode = new XorLinkedListNode(this, rootNodeValue, 0, 0);
            memory.Add(0, topNode);
        }

        public XorLinkedListMemoryDictionary(IEnumerable<string> values, string rootNodeValue = "root", int seed = 0)
        {
            if (seed == 0) { rand = new Random(); }
            else { rand = new Random(seed); }
            memory = new Dictionary<int, XorLinkedListNode>();
            topNode = new XorLinkedListNode(this, rootNodeValue, 0, 0);
            memory.Add(0, topNode);
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public XorLinkedListNode this[int key] { get => memory[key]; set => memory[key] = value; }
        private void Add(XorLinkedListNode node)
        {
            memory.Add(node.Pointer, node);
            topNode.SetChild(node);
            topNode = node;
        }
        public XorLinkedListNode Add(string value)
        {
            var node = new XorLinkedListNode(this, value, rand.Next(), topNode.Pointer);
            Add(node);
            return node;
        }
        public IEnumerable<XorLinkedListNode> Traverse()
        {
            XorLinkedListNode current = this[0];
            var parent = 0;
            for (int i = 1; i < memory.Count; i++)
            {
                var next = current.Children(parent).First().Pointer;
                parent = current.Pointer;
                yield return current = this[next];
            }
        }
        public IEnumerator<XorLinkedListNode> GetEnumerator() => Traverse().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Traverse().GetEnumerator();
    }
}