using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A06AsyncAwait
{
    public class AsyncDemoClass
    {
        public async Task DoSomethingAsync()
        {
            await Task.CompletedTask;
        }
    }
}
