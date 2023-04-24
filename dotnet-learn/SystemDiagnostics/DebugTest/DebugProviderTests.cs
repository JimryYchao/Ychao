using System;
using System.Diagnostics;
using System.Reflection;

namespace dotnet_learn.SystemDiagnostics.DebugTest
{
    public class DebugProviderTests : ITest<DebugProviderTests>
    {
        protected override Type ref_Class => debugProvider.GetType();
        private readonly static FieldInfo debugProvider;

        private static MethodInfo s_WriteCore;
        private static MethodInfo s_FailCore;


        static DebugProviderTests()
        {
            debugProvider = typeof(Debug).GetField("s_provider", BindingFlags.Static | BindingFlags.NonPublic);
            s_WriteCore = debugProvider.GetValue(null).GetType().GetMethod("WriteCore", BindingFlags.Static | BindingFlags.Public);
            s_FailCore = debugProvider.GetValue(null).GetType().GetMethod("FailCore", BindingFlags.Static  | BindingFlags.Public);
        }

        public static void WriteCore(string message)
        {
            s_WriteCore.Invoke(null, new object[] { message });
        }

        public static void FailCore(string? stackTrace, string? message, string? detailMessage, string? category = "Assertion failed.")
        {
            s_FailCore.Invoke(null, new object?[] { stackTrace, message, detailMessage, category });
        }

        public override void Test()
        {
            WriteCore("Test DebugProvider WriteCore.");

            FailCore(null, "Test DebugProvider FailCore." + StackTraceHelper.AtLine(), null);
        }
    }
}
