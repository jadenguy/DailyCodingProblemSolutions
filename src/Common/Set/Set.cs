using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common.Sets
{
    public class Set<T> : IEnumerable<SetElement<T>> where T : IEquatable<T>
    {
        List<SetElement<T>> containedSet = new List<SetElement<T>>();
        public Set(IEnumerable<SetElement<T>> elements) => containedSet = new List<SetElement<T>>(elements.ElementsToNewElements());
        public Set(IEnumerable<T> elements) => containedSet = new List<SetElement<T>>(elements.TypeEnumerableToElements());
        public Set(T element) { containedSet = new List<SetElement<T>>() { new SetElement<T>(element) }; }
        public Set() { }
        public void Add(SetElement<T> element) => containedSet.Add(new SetElement<T>(element));
        public void Add(T element) => containedSet.Add(new SetElement<T>(element));
        public void Add(IEnumerable<SetElement<T>> elements) => containedSet.AddRange(elements.ElementsToNewElements());
        public void Add(IEnumerable<T> elements) => containedSet.AddRange(elements.TypeEnumerableToElements());
        private IEnumerable<SetElement<T>> Render()
        {
            IEnumerable<SetElement<T>> cleanNotList = RemoveNottedElement(containedSet);
            IEnumerable<SetElement<T>> cleanXorList = RemoveDoubleXorredElement(cleanNotList);
            return containedSet = new List<SetElement<T>>(cleanXorList);
        }
        private IEnumerable<SetElement<T>> RemoveNottedElement(IEnumerable<SetElement<T>> set)
        {
            var not = new Queue<SetElement<T>>(set.Where(e => e.Not));
            if (not.Count == 0) { return set; }
            var existing = new Queue<SetElement<T>>(set.Where(e => !e.Not));
            while (not.Count > 0)
            {
                var current = not.Dequeue();
                var keepGoing = true;
                for (int i = 0; keepGoing && i < existing.Count(); i++)
                {
                    var other = existing.Dequeue();
                    SetElement<T> notOther = other.NotElement();
                    if (current.Equivalent(notOther)) { keepGoing = false; }
                    else { existing.Enqueue(other); } //ignore not matches
                }
            }
            return new List<SetElement<T>>(existing);
        }
        private IEnumerable<SetElement<T>> RemoveDoubleXorredElement(IEnumerable<SetElement<T>> set)
        {
            var xor = new Queue<SetElement<T>>(set.Where(e => e.Xor));
            if (xor.Count == 0) { return set; }
            var ret = new List<SetElement<T>>(set.Where(e => !e.Xor));
            while (xor.Count > 0)
            {
                var current = xor.Dequeue();
                var keepGoing = true;
                for (int i = 0; keepGoing && i < xor.Count; i++)
                {
                    var other = xor.Dequeue();
                    if (other.Equivalent(current)) { keepGoing = false; }
                    else { xor.Enqueue(other); } //ignore not matches
                }
                if (keepGoing) { ret.Add(current); }
            }
            return ret;
        }
        public bool SetEquivalent(IEnumerable<SetElement<T>> other) => Render().SetEquivalent(other);
        public IEnumerator<SetElement<T>> GetEnumerator() => Render().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Render().GetEnumerator();
        public override string ToString() => $"Count = {containedSet.Count}";
    }
}