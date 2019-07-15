using System;

namespace Common.RandomSelector
{
    public class StreamElementSelector<T>
    {
        private Random random;
        private int streamElementCount = 0;
        public T Element { get; set; }
        public StreamElementSelector(Random random = null)
        {
            if (random == null) { random = new Random(); }
            this.random = random;
        }
        public StreamElementSelector(T first)
        {
            Element = first;
            streamElementCount++;
        }
        public T SuggestElement(T newElement)
        {
            streamElementCount++;
            if (random.Next(streamElementCount) == 0)
            {
                Element = newElement;
            }
            return Element;
        }
    }
}