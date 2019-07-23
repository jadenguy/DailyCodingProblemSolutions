using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common.Sets
{
    public class Set : IEnumerable<SetElement>
    {
        List<SetElement> containedSet = new List<SetElement>();
        public Set(IEnumerable<SetElement> elements) => containedSet = new List<SetElement>(ElementsToNewElements(elements));
        public Set(IEnumerable<string> elements) => containedSet = new List<SetElement>(StringEnumerableToElements(elements));
        public Set() { }
        public void Add(SetElement element) => containedSet.Add(new SetElement(element));
        public void Add(string element) => containedSet.Add(new SetElement(element));
        public void Add(IEnumerable<SetElement> elements) => containedSet.AddRange(ElementsToNewElements(elements));
        public void Add(IEnumerable<string> elements) => containedSet.AddRange(StringEnumerableToElements(elements));
        private IEnumerable<SetElement> Render()
        {
            IEnumerable<SetElement> cleanNotList = RemoveNottedElement(containedSet);
            IEnumerable<SetElement> cleanXorList = RemoveDoubleXorredElement(cleanNotList);
            return containedSet = new List<SetElement>(cleanXorList);
        }
        private IEnumerable<SetElement> RemoveNottedElement(IEnumerable<SetElement> set)
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
        private IEnumerable<SetElement> RemoveDoubleXorredElement(IEnumerable<SetElement> set)
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
        public bool SetEquivalent(IEnumerable<SetElement> other) => Render().SetEquivalent(other);
        private static IEnumerable<SetElement> ElementsToNewElements(IEnumerable<SetElement> elements) => elements.Select(k => new SetElement(k));
        private static IEnumerable<SetElement> StringEnumerableToElements(IEnumerable<string> elements) => elements.Select(k => new SetElement(k));
        public IEnumerator<SetElement> GetEnumerator() => Render().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Render().GetEnumerator();
        public override string ToString() => $"Count = {containedSet.Count}";
    }
}