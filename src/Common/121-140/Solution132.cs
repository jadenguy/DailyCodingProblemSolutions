using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution132
    {
        public class HitCounter
        {
            private Dictionary<DateTime, int> dt = new Dictionary<DateTime, int>();
            public HitCounter() { }
            public void Record(DateTimeOffset? hitTime = null)
            {
                DateTime time = hitTime?.UtcDateTime ?? System.DateTime.UtcNow;
                dt[time] = 1 + (dt.ContainsKey(time) ? dt[time] : 0);
                dt.UpSert(time, n => n++);
            }
            public int Total() => dt.Values.Sum();
            public int Range(DateTimeOffset lower, DateTimeOffset upper) => dt.Where(kv => kv.Key >= lower && kv.Key <= upper).Sum(v => v.Value);
        }
    }
}