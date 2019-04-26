using System;

namespace Common
{
    public class StreamElementSelector<T>
    {
        private Random random = new Random();
        private int streamElementCount = 0;
        public T Element { get; set; }
        public StreamElementSelector()
        {
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