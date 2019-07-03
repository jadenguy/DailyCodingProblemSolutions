using System;

namespace Common.Forex
{
    public class Exchange : IEquatable<Exchange>
    {
        public Exchange(Currency oldCurrency, Currency newCurrency)
        {
            this.OldCurrency = oldCurrency;
            this.NewCurrency = newCurrency;
        }
        public Currency OldCurrency { get; set; }
        public Currency NewCurrency { get; set; }
        public bool Equals(Exchange other) => this.OldCurrency == other.OldCurrency && this.NewCurrency == other.NewCurrency;
        public override int GetHashCode() => ToString().GetHashCode();
        public override string ToString() => $"{OldCurrency} to {NewCurrency}";
    }
}
