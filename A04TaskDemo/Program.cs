using System;
using System.Threading;
using System.Threading.Tasks;

namespace A04TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int taskCount = 1000;
            Task[] allTasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                allTasks[i] = new Task<bool>(() =>
                {
                    // We can't do Task.Delay here, since that would make the
                    // lambda async, which it can't be in this particular instance.
                    Thread.Sleep(100);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    return true;
                });
                allTasks[i].Start();
            }
            Task.WaitAll(allTasks);
        }
    }
}
