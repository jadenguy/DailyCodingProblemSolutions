using System;
using System.Collections.Generic;

namespace Common.Node
{
    public class XorLinkedListNode : Node<XorLinkedListNode>
    {
        public XorLinkedListNode(XorLinkedListMemoryDictionary controller, string value, int pointer = 0, int parent = 0)
        {
            this.Value = value;
            this.Pointer = pointer;
            this.Both = parent;
            this.controller = controller;
        }
        public string Value { get; set; }
        public int Both { get; private set; }
        public int Pointer { get; set; }
        private XorLinkedListMemoryDictionary controller;
        public override IEnumerable<XorLinkedListNode> Children()
        {
            return this.Children(0);
        }
        public IEnumerable<XorLinkedListNode> Children(int parentIndex)
        {
            var child = Both ^ parentIndex;
            yield return  controller[child];
            ;
        }
        public void SetChild(XorLinkedListNode child)
        {
            Both ^= child.Pointer;
        }
        public override string ToString()=>$"[{Pointer}] {Value}";
    }
}