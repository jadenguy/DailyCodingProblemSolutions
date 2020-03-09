using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution132
    {
        public class HitCounter
        {
            private List<DateTimeOffset> dt = new List<DateTimeOffset>();
            public HitCounter() { }
            public void Record(DateTimeOffset? hitTime = null) => dt.Add(hitTime ?? System.DateTimeOffset.Now);
            public int Total() => dt.Count;
            public int Range(DateTimeOffset lower, DateTimeOffset upper) => dt.Where(h => h >= lower && h <= upper).Count();
        }
    }
}