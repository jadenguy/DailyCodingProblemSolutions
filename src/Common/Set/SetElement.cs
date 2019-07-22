using System;

namespace Common.Sets
{
    public class SetElement : IElement<String>
    {
        public SetElement(string value)
        {
            Value = value;
            Xor = false;
            Not = false;
        }
        public SetElement(string value, bool not, bool xor)
        {
            Value = value;
            Not = not;
            Xor = xor;
        }
        public SetElement(SetElement that)
        {
            Value = that.Value;
            Not = that.Not;
            Xor = that.Xor;
        }
        public string Value { get; set; }
        public bool Not { get; private set; }
        public bool Xor { get; private set; }
        public override string ToString()
        {
            var ret = string.Empty;
            if (Not) { ret += "Not "; }
            if (Xor) { ret += "Xor "; }
            return ret + Value;
        }
        // public bool NotThis() => Not = !Not;
        // public bool XorThis() => Xor = !Xor;
        public bool Equivalent(IElement<string> other)
        {
            var that = other as SetElement;
            if (that == null) { return false; }
            else { return this.Value.Equals(that.Value) && this.Xor == that.Xor && this.Not == that.Not; }
        }
        public SetElement NotElement() => new SetElement(Value, !Not, Xor);
        public SetElement XorElement() => new SetElement(Value, Not, !Xor);
        public SetElement NotXorElement() => new SetElement(Value, !Not, !Xor);
    }
}