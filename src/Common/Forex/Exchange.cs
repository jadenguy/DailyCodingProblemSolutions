using System;

namespace Common.Forex
{
    public class Exchange : IEquatable<Exchange>
    {
        public Exchange(Currency oldCurrency, Currency newCurrency, double exchangeRate = 1)
        {
            this.OldCurrency = oldCurrency;
            this.NewCurrency = newCurrency;
            this.ExchangeRate = exchangeRate;
        }
        public Currency OldCurrency { get; set; }
        public Currency NewCurrency { get; set; }
        public double ExchangeRate { get; set; }
        public bool Equals(Exchange other) => this.OldCurrency == other.OldCurrency && this.NewCurrency == other.NewCurrency && this.ExchangeRate == other.ExchangeRate;
        public override int GetHashCode() => ToString().GetHashCode();
        public override string ToString() => $"{OldCurrency} to {NewCurrency} at a rate of {ExchangeRate}";
    }
}
