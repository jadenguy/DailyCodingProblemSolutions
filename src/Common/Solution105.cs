using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public static class Solution105
    {
        public static Dictionary<Func<int, int>, Task<int>> list = new Dictionary<Func<int, int>, Task<int>>();
        public static Task<int> Debounce(Func<int, int> func, int number, int time)
        {
            if (!list.ContainsKey(func) || list[func].IsCompleted)
            {
                list[func] = Task.Run(() =>
                {
                    Thread.Sleep(time);
                    return func(number);
                });
            }
            return list[func];
        }
    }
}