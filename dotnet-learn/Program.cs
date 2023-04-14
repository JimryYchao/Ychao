using dotnet_learn.SystemDiagnostics.DebugTest;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace dotnet_learn
{
    internal class Program
    {
        [DisallowNull]
        string str = null;

        static void Main(string[] args)
        {
            DebugTests dt = new DebugTests();
            System.Console.WriteLine(dt.Get(" ") ?? "Null");


        }


        [DisallowNull]
        static int a;

        public static string Test()
        {
            return null;
        }
    }
}