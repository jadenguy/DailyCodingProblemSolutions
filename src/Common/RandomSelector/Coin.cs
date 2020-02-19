namespace Common
{
    public class Coin
    {
        private static System.Random rand;
        private static object l = new object();
        bool? heads;
        public Coin() => rand = rand ?? new System.Random();
        public Coin(int seed) => rand = rand ?? ((seed == 0) ? new System.Random() : new System.Random(seed));
        public bool? HeadsStatus { get => heads; set => heads = value; }
        public bool IsHead => HeadsStatus == true;
        public bool IsTails => HeadsStatus == false;
        public bool Flip()
        {
            lock (l)
            {
                HeadsStatus = rand.NextDouble() > .5;
                return HeadsStatus == true;
            }

        }
        public override string ToString() => (heads is null) ? "U" : ((heads == true) ? "H" : "T");
    }
}