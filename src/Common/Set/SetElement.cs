using System;

namespace Common.Sets
{
    public class SetElement<T> where T : IEquatable<T>
    {
        public SetElement(T value)
        {
            Value = value;
            Xor = false;
            Not = false;
        }
        public SetElement(T value, bool not, bool xor)
        {
            Value = value;
            Not = not;
            Xor = xor;
        }
        public SetElement(SetElement<T> that)
        {
            Value = that.Value;
            Not = that.Not;
            Xor = that.Xor;
        }
        public T Value { get; set; }
        public bool Not { get; private set; }
        public bool Xor { get; private set; }
        [System.Diagnostics.DebuggerStepThrough]
        public override string ToString()
        {
            var ret = string.Empty;
            if (Not) { ret += "Not "; }
            if (Xor) { ret += "Xor "; }
            return ret + Value;
        }
        public bool Equivalent(SetElement<T> other)
        {
            var that = other as SetElement<T>;
            if (that == null) { return false; }
            else { return this.Value.Equals(that.Value) && this.Xor == that.Xor && this.Not == that.Not; }
        }
        [System.Diagnostics.DebuggerStepThrough] public SetElement<T> NotElement() => new SetElement<T>(Value, !Not, Xor);
        [System.Diagnostics.DebuggerStepThrough] public SetElement<T> XorElement() => new SetElement<T>(Value, Not, !Xor);
        [System.Diagnostics.DebuggerStepThrough] public SetElement<T> NotXorElement() => new SetElement<T>(Value, !Not, !Xor);
    }
}