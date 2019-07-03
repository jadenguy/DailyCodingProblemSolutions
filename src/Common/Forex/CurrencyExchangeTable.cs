using System.Collections.Generic;
using System.Text;

namespace Common.Forex
{
    public class CurrencyExchangeTable : Dictionary<Exchange, decimal>
    {
        public string Print()
        {
            var x = new StringBuilder();
            foreach (var item in this)
            {
                x.AppendLine(this.Keys.ToString());
            }
            return x.ToString();
        }
    }
}
