using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A06AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncDemoClass.LotsOfParallelTasksAsync().Wait();
        }
    }
}
