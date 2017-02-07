using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A06AsyncAwait
{
    public static class AsyncDemoClass
    {
        static async Task DoSomethingAsync()
        {
            await Task.Delay(100);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task LotsOfParallelTasksAsync()
        {
            int taskCount = 1000;
            Task[] allTasks = Enumerable.Range(0, taskCount).Select(i => DoSomethingAsync()).ToArray();
            await Task.WhenAll(allTasks);
        }

        public static async Task LotsOfSequentialTasksAsync()
        {
            int taskCount = 1000;
            for (int i = 0; i < taskCount; i++)
            {
                await DoSomethingAsync();
            }
        }

        
    }
}
