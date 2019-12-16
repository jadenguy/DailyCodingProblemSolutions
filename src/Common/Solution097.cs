using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution097
    {
        public class Map
        {
            // // This is totally unclear. Are you supposed to blank out all times when a new time comes in or not?
            // List<int> keys = new List<int>();
            // List<int> times = new List<int>();
            // List<int> values = new List<int>();
            // public Map() { }
            // public void Set(int key, int value, int time)
            // {
            //     var foundKey = false;
            //     for (int i = 0; !foundKey && i < keys.Count; i++)
            //     {
            //         if (keys[i] == key)
            //         {
            //             times[i] = time;
            //             values[i] = value;
            //             foundKey = true;
            //         }
            //     }
            //     if (!foundKey) { keys.Add(key); values.Add(value); times.Add(time); }
            // }
            // public int? Get(int key, int time)
            // {
            //     var foundKey = false;
            //     for (int i = 0; !foundKey && i < keys.Count; i++)
            //     {
            //         if (keys[i] == key)
            //         {
            //             if (times[i] <= time) { return values[i]; }
            //             else { return null; }
            //         }
            //     }
            //     return null;
            // }
            private Dictionary<int, Dictionary<int, int>> elements = new Dictionary<int, Dictionary<int, int>>();
            public Map() { }
            public void Set(int key, int value, int time)
            {
                if (!elements.ContainsKey(key)) { elements.Add(key, new Dictionary<int, int>()); }
                elements[key][time] = value;
            }
            public int? Get(int key, int time)
            {
                if (!elements.ContainsKey(key)) { return null; }
                var timeIndexBeforeTime = elements[key].Keys.Where(t => t <= time).OrderByDescending(t => t)?.First();
                if (timeIndexBeforeTime == null) { return null; }
                else
                {
                    return elements[key][(int)timeIndexBeforeTime];
                }
            }
        }
    }
}