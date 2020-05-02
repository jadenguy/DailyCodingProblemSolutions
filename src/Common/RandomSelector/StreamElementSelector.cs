using System;

namespace Common.RandomSelector
{
    public class StreamElementSelector<T>
    {
        private System.Random random;
        private int streamElementCount = 0;
        public T Element { get; set; }
        public StreamElementSelector(int seed = 0) => random = Rand.NewRandom(seed);
        public StreamElementSelector(T first)
        {
            Element = first;
            streamElementCount++;
        }
        public T SuggestElement(T newElement)
        {
            streamElementCount++;
            if (random.Next(streamElementCount) == 0) { Element = newElement; }
            return Element;
        }
    }
}