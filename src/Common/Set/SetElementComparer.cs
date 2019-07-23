using System;
using System.Collections.Generic;

namespace Common.Sets
{
    public class SetElementComparer<T> : IEqualityComparer<SetElement<T>> where T : IEquatable<T>
    {
        public bool Equals(SetElement<T> x, SetElement<T> y) => x.Equivalent(y);
        public int GetHashCode(SetElement<T> obj) => obj.ToString().GetHashCode();
    }
}
