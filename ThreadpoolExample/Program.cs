using System;
using System.Linq;
using System.Threading;

namespace ThreadpoolExample
{
    class Program
    {
        private static int _finishedItems;

        static void Main(string[] args)
        {
            int taskCount = 1000;
            Enumerable.Range(0, taskCount).ToList().ForEach(i => ThreadPool.QueueUserWorkItem(WorkItem));
            while (_finishedItems < taskCount)
            {
                Thread.Sleep(100);
            }
        }

        private static void WorkItem(object state)
        {
            Thread.Sleep(100);
            Interlocked.Increment(ref _finishedItems);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
