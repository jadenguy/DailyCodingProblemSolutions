using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common.Sets
{
    public class Set : IEnumerable<SetElement>
    {
        HashSet<SetElement> containedSet = new HashSet<SetElement>();
        public Set(IEnumerable<SetElement> setElements) => containedSet = new HashSet<SetElement>(setElements.Select(k => new SetElement(k)));
        public Set(string[] setElements) => containedSet = new HashSet<SetElement>(setElements.Select(k => new SetElement(k)));
        public Set() { }
        private IEnumerable<SetElement> Render()
        {
            var xor = new Queue<SetElement>(containedSet.Where(e => e.Xor));
            var ret = new List<SetElement>();
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
            // ret.AddRange(containedSet.Where(e => !e.Xor));
            var not = new Queue<SetElement>(containedSet.Where(e => e.Not));
            // while (not.Count > 0)
            // {
            //     var current = not.Dequeue();
            //     var keepGoing = true;
            //     for (int i = 0; keepGoing && i < xor.Count; i++)
            //     {
            //         var other = xor.Dequeue();
            //         if (other.Equivalent(current)) { keepGoing = false; }
            //         else { xor.Enqueue(other); } //ignore not matches
            //     }
            // }
            // return containedSet = new HashSet<SetElement>(containedSet);
            return containedSet = new HashSet<SetElement>(ret);
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