using System;
using System.Diagnostics;

namespace A01Processes
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo(".\\a01subprocess.exe")
                {
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                }
            };
            p.ErrorDataReceived += (s, a) => Console.WriteLine($"Calling process received on stderr: \"{a.Data}\"");
            p.OutputDataReceived += (s, a) => Console.WriteLine($"Calling process received on stdout: \"{a.Data}\"");


            p.Start();
            p.BeginOutputReadLine();
            Console.ReadLine();
            p.Kill();
            p.WaitForExit();
        }
    }
|
