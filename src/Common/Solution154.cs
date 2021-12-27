using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Collections;

namespace Common
{
    public partial class Solution154
    {
        public class Stack<T> : IEnumerable<T>
        {
            private IHeap<StackHeapCarrier<T>> heap = new FakeHeap<StackHeapCarrier<T>>(IHeap<StackHeapCarrier<T>>.HeapMinMax.Max);
            private int count = 0;
            public Stack()
            {

            }
            public Stack(IEnumerable<T> elements)
            {
                foreach (var element in elements)
                {
                    Push(element);
                }
            }
            private int Count { get => count; set => count = value; }
            public void Add(T element) => Push(element);

            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
            public void Push(T element)
            {
                heap.Push(new StackHeapCarrier<T>(Count++, element));

            }
            public T Pop() => heap.Pop().Value;
        }
        public class StackHeapCarrier<T> : IComparable<StackHeapCarrier<T>>
        {
            private readonly int Index;
            public readonly T Value;
            public StackHeapCarrier(int index, T value)
            {
                Index = index;
                Value = value;
            }
            public int CompareTo(StackHeapCarrier<T> other)
            {
                return this.Index.CompareTo(other.Index);
            }
        }
    }
}