namespace Common
{
    public static class Rand
    {
        public static System.Random NewRandom(this int? seed) => NewRandom(0);
        public static System.Random NewRandom(this int seed)
        {
            return seed == 0 ? new System.Random() : new System.Random(seed);
        }
    }
}