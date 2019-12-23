using System;
using System.Collections.Generic;
using System.Threading.Tasks;
// using System.Threading;
// using System.Threading.Tasks;

namespace Common
{
    public static class Solution105
    {
        public static Dictionary<Func<int, int>, TaskWaiter> list = new Dictionary<Func<int, int>, TaskWaiter>();
        public static TaskWaiter Debounce(Func<int, int> func, int number, int milliseconds, bool fast = false)
        {
            if (!list.ContainsKey(func) || list[func].IsCompleted)
            {
                list[func] = new TaskWaiter(Task.Run(() => func(number)), milliseconds, fast);
            }
            return list[func];
        }
    }
    public class TaskWaiter
    {
        public bool IsCompleted
        {
            get
            {
                if (fast)
                {
                    return waiter.IsCompleted || GetTask().IsCompleted;
                }
                else
                {
                    return waiter.IsCompleted && GetTask().IsCompleted;
                }
            }
        }
        private Task<int> task;
        private Task waiter;
        private bool fast;
        public TaskWaiter(Task<int> task, int milliseconds, bool fast = false)
        {
            this.task = task;
            this.waiter = Task.Delay(milliseconds);
        }
        public Task<int> GetTask() => task;
        public System.Runtime.CompilerServices.TaskAwaiter<int> GetAwaiter() => GetTask().GetAwaiter();
    }
}