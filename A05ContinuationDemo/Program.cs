using System;
using System.Threading;
using System.Threading.Tasks;

namespace A05ContinuationDemo
{
    class Program
    {
        private static int currentInstance = 0;

        static void Main(string[] args)
        {
            Task start = new Task(() => Dosomething());
            Task current = start;
            for (int i = 0; i < 1000; i++)
            {
                current = current.ContinueWith(Dosomething);
            }
            start.Start();
            current.Wait();
        }

        static void Dosomething(Task previous = null)
        {
            Task.Delay(100);
            Console.WriteLine($"{currentInstance++}\t{Thread.CurrentThread.ManagedThreadId}");
        }
    }

}
