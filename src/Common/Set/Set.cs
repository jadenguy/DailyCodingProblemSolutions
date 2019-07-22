using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common.Sets
{
    public class Set : IEnumerable<SetElement>
    {
        List<SetElement> containedSet = new List<SetElement>();
        public Set(IEnumerable<SetElement> setElements) => containedSet = setElements.Select(k => new SetElement(k)).ToList();
        public Set(IEnumerable<string> setElements) => containedSet = setElements.Select(k => new SetElement(k)).ToList();
        public Set() { }
        public void Add(SetElement element) => containedSet.Add(element);
        public void Add(string element) => containedSet.Add(new SetElement(element));
        public void Add(IEnumerable<SetElement> elements) => containedSet.AddRange(elements);
        public void Add(IEnumerable<string> elements) => containedSet.AddRange(elements.Select(k => new SetElement(k)));

        private IEnumerable<SetElement> Render()
        {
            IEnumerable<SetElement> cleanNotList = RemoveNotElement(containedSet);
            IEnumerable<SetElement> cleanXorList = RemoveDoubleXor(cleanNotList);
            return containedSet = new List<SetElement>(cleanXorList);
        }
        private IEnumerable<SetElement> RemoveNotElement(IEnumerable<SetElement> set)
        {
            var not = new Queue<SetElement>(set.Where(e => e.Not));
            if (not.Count == 0) { return set; }
            var existing = new Queue<SetElement>(set.Where(e => !e.Not));
            while (not.Count > 0)
            {
                var current = not.Dequeue();
                var keepGoing = true;
                for (int i = 0; keepGoing && i < existing.Count(); i++)
                {
                    var other = existing.Dequeue();
                    SetElement notOther = other.NotElement();
                    if (current.Equivalent(notOther)) { keepGoing = false; }
                    else { existing.Enqueue(other); } //ignore not matches
                }
            }
            return new List<SetElement>(existing); 
        }
        private IEnumerable<SetElement> RemoveDoubleXor(IEnumerable<SetElement> set)
        {
            var xor = new Queue<SetElement>(set.Where(e => e.Xor));
            if (xor.Count == 0) { return set; }
            var ret = new List<SetElement>(set.Where(e => !e.Xor));
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
        public bool SetEquivalent(IEnumerable<SetElement> other) => SetEquivalent(Render(), other);
        public static bool SetEquivalent(IEnumerable<SetElement> expected, IEnumerable<SetElement> actual)
        {
            var countSame = expected.Count() == actual.Count();
            SetElementComparer comparer = new SetElementComparer();
            var x = expected.Except(actual, comparer);
            var y = actual.Except(expected, comparer);
            var sameContent = !x.Any() && !y.Any();
            return countSame && sameContent;
        }
        public IEnumerator<SetElement> GetEnumerator() => Render().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Render().GetEnumerator();
    }
}