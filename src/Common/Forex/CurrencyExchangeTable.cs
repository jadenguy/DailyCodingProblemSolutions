using System.Collections.Generic;
using System.Linq;

namespace Common.Forex
{
    public class CurrencyExchangeTable : List<Exchange>
    {
        public new void Add(Exchange x)
        {
            IEnumerable<Exchange> enumerable = this.Where(e => e.OldCurrency == x.OldCurrency && e.NewCurrency == x.NewCurrency);
            if (!this.Contains(x) && !enumerable.Any())
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
