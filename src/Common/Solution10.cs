using System;
using System.Threading.Tasks;

namespace Common
{
    public static class Solution10
    {
        public static async Task<Task> TaskScheduler(Action action, int delay)
        {
            var millisecondsDelay = delay * 1000;
            await Task.Delay(millisecondsDelay);
            return Task.Run(action);
        }
    }
}