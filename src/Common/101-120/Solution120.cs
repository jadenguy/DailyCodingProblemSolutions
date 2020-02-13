namespace Common
{
    public class Solution120
    {
        public static int GetInstance { get => SingletonIntStorage.Instance; set => SingletonIntStorage.Instance = value; }
        public static class SingletonIntStorage
        {
            private static int a;
            private static int b;
            private static object l = new object();
            private static bool x = false;
            public static int Instance
            {
                get
                {
                    lock (l)
                    {
                        return X ? a : b;
                    }
                }
                set
                {
                    lock (l)
                    {
                        if (X) { a = value; } else { b = value; }
                    }
                }
            }
            public static bool X
            {
                get
                {
                    lock (l)
                    {
                        x = !x;
                        return x;
                    }
                }
                set
                {
                    lock (l)
                    {
                        x = !x;
                        x = value;
                    }
                }
            }
        }
    }

}
