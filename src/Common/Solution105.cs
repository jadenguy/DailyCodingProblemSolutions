using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public static class Solution105
    {
        private static Dictionary<Func<int, int>, DateTime> dictionary;
        public static Task<int> Debounce(Func<int, int> func, int number, int time)
        {
            return Task.Run(() =>
                {
                    Thread.Sleep(time);
                    return func(number);
                }
            );
        }
    }
}