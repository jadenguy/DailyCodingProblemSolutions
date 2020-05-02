using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool IsLoop
        {
            get
            {
                Exchange current;
                var previous = this.Last();
                var ret = true;
                for (int i = 0; ret && i < this.Count; i++)
                {
                    current = this[i];
                    ret = current.OldCurrency == previous.NewCurrency;
                    previous = current;
                }
                return ret;
            }
        }
    }
}