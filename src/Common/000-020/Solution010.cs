using System;
using System.Threading.Tasks;

namespace Common
{
    public static class Solution010

    {
        public static async Task<Task> TaskScheduler(Action action, int delay)
        {
            var millisecondsDelay = delay;
            await Task.Delay(millisecondsDelay);
            return Task.Run(action);
        }
    }
}