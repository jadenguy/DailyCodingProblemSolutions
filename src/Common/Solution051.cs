using System;
using System.Linq;

namespace Common
{
    public class Solution051
    {
        public static int[] SwapShuffleDeck(int seed = 0, int cards = 52)
        {
            Random rand;
            if (seed == 0) { rand = new Random(); }
            else { rand = new Random(seed); }
            var deck = Enumerable.Range(1, cards).ToArray();
            for (int i = 0; i < cards; i++)
            {
                Swap(deck, i, rand.Next(cards));
            }
            return deck;
        }
        private static void Swap(int[] deck, int x, int y)
        {
            var z = deck[x];
            deck[x] = deck[y];
            deck[y] = z;
        }
    }
}