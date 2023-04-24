using dotnet_learn.SystemDiagnostics.DebugTest;

namespace dotnet_learn
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            //DebuggerTests.Instance.Test();

            DebugProviderTests.Instance.Test(); 
        }
    }
}