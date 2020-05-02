namespace Common
{
    public class Coin
    {
        private static System.Random rand;
        private static object l = new object();
        bool? heads;
        public Coin(int seed = 0) => rand = Rand.NewRandom(seed);
        public bool? HeadsStatus { get => heads ?? Flip(); }
        public bool Flip()
        {
            lock (l)
            {
                heads = rand.NextDouble() > .5;
                return HeadsStatus == true;
            }
        }
        public override string ToString() => (heads is null) ? "U" : ((heads == true) ? "H" : "T");
    }
}