using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.Collections
{
    public class Stack<T> : IEnumerable<T>
    {
        private int capacityRoot = 1024;
        private int length = 0;
        private T[][] elements;
        public int Length { get => length; set => length = value; }
        public Stack()
        {
            elements = new T[capacityRoot][];
            elements[0] = new T[capacityRoot];
        }
        public T this[int index]
        {
            get
            {
                if (index > length) { throw new IndexOutOfRangeException(); }
                return elements[(index) / capacityRoot][(index) % capacityRoot];
            }
            private set
            {
                if (index > length) { throw new IndexOutOfRangeException(); }
                int superArray = index / capacityRoot;
                if (elements[superArray] == null) { elements[superArray] = new T[capacityRoot]; }
                int localArray = index % capacityRoot;
                elements[superArray][localArray] = value;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                T ret = this[i];
                yield return ret;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        public void Push(T value)
        {
            this[Length++] = value;
            // Length++;
        }
        public T Pop()
        {
            Length--;
            return this[Length];
        }
        public T Peek() => this[Length - 1];
    }
}