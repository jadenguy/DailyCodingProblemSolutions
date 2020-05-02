using System.Collections.Generic;
using System.Linq;

namespace Common.Forex
{
    public class CurrencyExchangeTable : List<Exchange>
    {
        public new void Add(Exchange x)
        {
            if (!this.Contains(x) && !this.Any(e => e.OldCurrency == x.OldCurrency && e.NewCurrency == x.NewCurrency))
            {
                ((List<Exchange>)this).Add(x);
            }
            else
            {
                throw new System.ArgumentException("Exchange already exists.");
            }
        }
    }
}
