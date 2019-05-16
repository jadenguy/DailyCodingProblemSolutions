using System;

namespace Common
{
    public static class Solution5
    {
        public class Pair
        {
            public int a { get; private set; }
            public int b { get; private set; }
            public Pair(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
        }
        public static Pair Cons(int a, int b) => new Pair(a, b);
        public static int Car(Pair pair) => pair.a;
        public static int Cdr(Pair pair) => pair.b;
    }
}