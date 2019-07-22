using System.Collections.Generic;

namespace Common.Sets
{
    public class SetElementComparer : IEqualityComparer<SetElement>
    {
        public bool Equals(SetElement x, SetElement y) => x.Equivalent(y);
        public int GetHashCode(SetElement obj) => obj.ToString().GetHashCode();
    }
}
