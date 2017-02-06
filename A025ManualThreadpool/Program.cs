using System;
using System.Collections.Concurrent;
using System.Threading;

namespace A025ManualThreadpool
{
    class Program
    {


        static void Main(string[] args)
        {
            // setup
            int noOfWorkItems = 1000;
            int workerThreadCount = 2;

            using (BlockingCollection<Action> workQueue = new BlockingCollection<Action>())
            {
                Thread[] workerthreads = new Thread[2];
                for (int i = 0; i < workerThreadCount; i++)
                {
                    workerthreads[i] = new Thread(FetchAndWork);
                    workerthreads[i].Start(workQueue);
                }

                for (int i = 0; i < noOfWorkItems; i++)
                {
                    workQueue.Add(() => Console.WriteLine(Thread.CurrentThread.ManagedThreadId));
                }

                // Polling until we are finished
                while (workQueue.Count > 0)
                {
                    Thread.Sleep(100);
                }
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();

                // Killing everything
                foreach (Thread workerthread in workerthreads)
                {
                    workerthread.Abort();
                }
            }
        }

        private static void FetchAndWork(object queue)
        {
            BlockingCollection<Action> workQueue = (BlockingCollection<Action>) queue;
            while (true)
            {
                Action a = workQueue.Take();
                try
                {
                    a();
                }
                catch
                {
                    // We don't want any handling here.
                }
            }
        }
    }
}
