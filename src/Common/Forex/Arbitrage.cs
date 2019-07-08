namespace Common.Forex
{

    public class Arbitrage
    {
        public Arbitrage(ExchangeChain chain, decimal ratio)
        {
            this.Chain = chain;
            this.Ratio = ratio;

        }
        public ExchangeChain Chain { get; set; }
        public decimal Ratio { get; set; }
    }
}
