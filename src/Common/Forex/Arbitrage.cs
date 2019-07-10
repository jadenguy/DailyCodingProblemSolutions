namespace Common.Forex
{

    public class Arbitrage
    {
        public Arbitrage(ExchangeChain chain, double ratio)
        {
            this.Chain = chain;
            this.Ratio = ratio;

        }
        public ExchangeChain Chain { get; set; }
        public double Ratio { get; set; }
    }
}
