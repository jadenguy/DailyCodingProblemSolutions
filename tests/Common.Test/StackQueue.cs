using System;
using System.Collections.Generic;

namespace Common
{
    public class StackQueue<T>
    {
        private object queueLock = new object();
        private Stack<T> queue = new Stack<T>();
        private Stack<T> reverseQueue = new Stack<T>();
        public StackQueue() { }

        public void Enqueue(T v)
        {
            queue.Push(v);
        }

        public T Dequeue()
        {
            T ret;
            lock (queueLock)
            {
                while (queue.Count > 0)
                {
                    reverseQueue.Push(queue.Pop());
                }
                ret = reverseQueue.Pop();
                while (reverseQueue.Count > 0)
                {
                    queue.Push(reverseQueue.Pop());
                }
                return ret;
            }
        }
    }
}