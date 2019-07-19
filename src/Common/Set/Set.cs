using System.Collections.Generic;
using System.Linq;

namespace Common.Sets
{
    public class Set
    {
        HashSet<SetElement> containedSet = new HashSet<SetElement>();

        public Set(IEnumerable<SetElement> setElement)
        {
            foreach (var item in setElement)
            {
                containedSet.Add(item);
            }
        }
        public Set(string[] v)
        {

        }
        public Set Not(Set set)
        {
            return this;
        }
        public HashSet<SetElement> Contents { get => Render(containedSet); }
        private HashSet<SetElement> Render(HashSet<SetElement> contents)
        {
            var xor = new Queue<SetElement>(contents.Where(e => e.Xor));
            var not = new Queue<SetElement>(contents.Where(e => e.Not));
            var exists = new Queue<SetElement>(contents.Where(e => !e.Not));
            while (xor.Count > 0)
            {
                var current = xor.Dequeue();
                var match = xor.Select(x => x).Where(z => z.IsSame(current)).FirstOrDefault();
            }
            return containedSet;
        }
    }
}