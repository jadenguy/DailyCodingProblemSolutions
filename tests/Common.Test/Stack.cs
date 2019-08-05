using System;
using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public class Stack<T> : IEnumerable<T>
    {
        private int capacity = 1000;
        private int index = -1;
        private T[] elements;
        public Stack()
        {
            elements = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= index; i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Push(T v)
        {
            index++;
            elements[index]=v;
        }

        public T Pop()
        {
            var ret= elements[index];
            index--;
            return ret;
        }

        public T Peek()
        {
            return elements[index];
        }
    }
}