using System.Collections.Generic;

namespace Common.Forex
{
    public class ExchangeChain : List<Exchange>
    {
        public ExchangeChain()
        {
        }

        public ExchangeChain(IEnumerable<Exchange> collection) : base(collection)
        {
        }
    }
}