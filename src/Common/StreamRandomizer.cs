using System;

namespace Common
{
    public class StreamRandomizer<T>
    {
        private Random random = new Random();
        private int streamElementCount = 0;
        public T Element { get; set; }
        public StreamRandomizer()
        {
        }
        public StreamRandomizer(T first)
        {
            Element = first;
            streamElementCount++;
        }
        public T RandomizeElement(T newElement)
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