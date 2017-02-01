using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace A02ThreadpoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // create threads
            List<Thread> threads = Enumerable.Range(0, 1000).Select(i =>
            {
                Thread t = new Thread((o) =>
                {
                    Thread.Sleep(10000);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                });
                // run thread
                t.Start();
                return t;
            }).ToList();
            // same in loop to show resource usage
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }
    }
}
