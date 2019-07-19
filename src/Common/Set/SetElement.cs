using System;

namespace Common.Sets
{
    public class SetElement : IElement<String>
    {
        public SetElement(string text)
        {
            Value = text;
            Xor = false;
            Not = false;
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
        public bool NotThis() => Not = !Not;
        public bool XorThis() => Xor = !Xor;
        public bool IsSame(IElement<string> other)
        {
            var that = other as SetElement;
            if (that == null) { return false; }
            else { return this.Equals(that) && this.Xor == that.Xor && this.Not == that.Not; }
        }
    }
}