using System;
using System.Diagnostics;

namespace Ychao.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int i = 10;
            //while (--i > 0)
            //    LogTest.LoggerTest();

            //Assert.Diagnostic(true);

            Log.InfoFormat(" hahah ");

            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.AutoFlush = true;
            Debug.Indent();
            Debug.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Debug.WriteLine("Exiting Main");
            Debug.Unindent();
            //while (true)
            //{
            //    var s = Console.ReadLine();
            //    Log.Info(s);
            //}

            //MonoEngineCore i = MonoEngineCore.Instance;
            //MonoCollecter.Instance = new MonoCollecter();
            //ISingleton<MonoCollecter>.Singleton.T();
        }
    }
}
