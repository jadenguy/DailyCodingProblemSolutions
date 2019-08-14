namespace Common.Collections
{
    public class StackQueue<T>
    {
        private object queueLock = new object();
        private System.Collections.Generic.Stack<T> queue = new System.Collections.Generic.Stack<T>();
        private System.Collections.Generic.Stack<T> reverseQueue = new System.Collections.Generic.Stack<T>();
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