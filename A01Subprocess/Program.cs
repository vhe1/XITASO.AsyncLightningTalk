using System;
using System.Diagnostics;

namespace A01Subprocess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello from subprocess {Process.GetCurrentProcess().Id} !");
            Console.ReadLine();
        }
    }
}
