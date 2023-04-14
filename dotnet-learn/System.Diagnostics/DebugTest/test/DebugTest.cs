using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace dotnet_learn.SystemDiagnostics.DebugTest
{
    public class DebugTests
    {
        public static void Cw([AllowNull]int a, [NotNull] string b)
        {
            Console.WriteLine(a + b);
        }


        [return : NotNullIfNotNull("key")]
        public string? Get(string? key)
        {
            return null;
        } 

    }

    public class C
    {


    }
}
