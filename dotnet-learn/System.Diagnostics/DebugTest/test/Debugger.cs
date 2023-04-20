using System;
using System.Diagnostics;
using System.Threading;

namespace dotnet_learn.SystemDiagnostics.Tests
{
    public class _Debugger
    {
        public static void Test()
        {
            Debugger.Break();

            if (Debugger.IsAttached)
                Console.WriteLine("Debugger is Attached." + new StackFrame(true));

            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
                if (Debugger.IsAttached)
                {
                    System.Console.WriteLine("Debugger Launch" + new StackFrame(true));
                    Debugger.Log(10, "category", "This is a test log message raised in the System.Diagnostics.Debug tests for the .NET Debugger class.");
                    Console.WriteLine(Debugger.IsLogging());
                }
            }

            int i = 1;

            new Thread(() =>
            {

                while (i++ < 10000)
                {
                    if (i % 1000 == 0)
                    {
                        Debugger.Break();
                        Debugger.Log(0, "Thread ID", Thread.CurrentThread.ManagedThreadId.ToString());
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
                    }
                }
            }).Start();

            while (i++ < 10000)
            {
                if (i % 1000 == 0)
                {
                    Debugger.Break();
                    Debugger.Log(0, "Thread ID", Thread.CurrentThread.ManagedThreadId.ToString());
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
                }
            }
        }
    }
}
