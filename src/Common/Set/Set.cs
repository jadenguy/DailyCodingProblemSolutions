using System.Collections.Generic;
using System.Linq;

namespace Common.Sets
{
    public class Set
    {
        HashSet<SetElement> containedSet = new HashSet<SetElement>();
        public Set(IEnumerable<SetElement> setElements) => containedSet = new HashSet<SetElement>(setElements.Select(k => new SetElement(k)));
        public Set(string[] setElements) => containedSet = new HashSet<SetElement>(setElements.Select(k => new SetElement(k)));
        public Set() { }
        public Set Not()
        {
            var ret = new Set(containedSet);
            ret.containedSet.Select(e => e.NotThis());
            return ret;
        }
        public HashSet<SetElement> Contents { get => new HashSet<SetElement>(Render(containedSet)) {  }; }
        private IEnumerable<SetElement> Render(HashSet<SetElement> contents)
        {
            var xor = new Queue<SetElement>(contents.Where(e => e.Xor));
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
            ret.AddRange(contents.Where(e => !e.Xor));
            // var not = new Queue<SetElement>(contents.Where(e => e.Not));
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
    }
}