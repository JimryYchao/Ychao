using System;
using System.Diagnostics;

namespace dotnet_learn.SystemDiagnostics.DebugTest
{
    public class DebugTests : ITest<DebuggerTests>
    {
        protected override Type ref_Class => typeof(System.Diagnostics.Debug);

        public override void Test()
        {

        }

        private readonly static Type DebugProvider;

        static DebugTests()
        {
            //DebugProvider = typeof(Debug).GetField("")
        }

         void WriteCoreTest(string message)
        {




        }

        public void FailCoreTest()
        {

        }





    }


}

