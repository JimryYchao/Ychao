using System;
using System.Diagnostics;
using System.Reflection;

namespace dotnet_learn.SystemDiagnostics.DebugTest
{
    public class DebuggerTests : ITest<DebuggerTests>
    {

        protected override Type ref_Class => typeof(System.Diagnostics.Debugger);

        public override void Test()
        {
            Instance.BreakTest();
            Instance.LogTest();
            Instance.DefaultCategoryTest();

            Instance.LaunchTest();
            Instance.NotifyOfCrossThreadDependencyTest();

            Instance.BreakTest();
            Instance.LogTest();
            Instance.DefaultCategoryTest();

            Instance.LaunchTest();
        }

        public void DefaultCategoryTest()
        {
            Console.WriteLine($"Debugger DefaultCategory : {Debugger.DefaultCategory}" + StackTraceHelper.AtLine());

            // Set DefaultCategory
            try
            {
                var DefaultCategory = typeof(Debugger).GetRuntimeField("DefaultCategory");
                if (!DefaultCategory?.IsInitOnly ?? false)
                {
                    DefaultCategory.SetValue(null, "TEST CATEGORY");
                    Console.WriteLine($"Debugger DefaultCategory Override : " + Debugger.DefaultCategory + StackTraceHelper.AtLine());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + StackTraceHelper.AtLine());
            }
        }


        /// <summary>
        /// 若未启用 Debugger，断点被忽略
        /// </summary>
        public void BreakTest()
        {
            Debugger.Break();
            if (Debugger.IsAttached)
                Console.WriteLine("Break 断点成功" + StackTraceHelper.AtLine());
            else Console.WriteLine("未启用 Debugger，断点测试失败" + StackTraceHelper.AtLine());
        }

        /// <summary>
        /// 选择启用调试器并附加到进程
        /// <br>PS: 请勿重新创建一个 VS 实例，请附加到已打开的 VS 实例</br>
        /// </summary>
        public void LaunchTest()
        {
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
                if (Debugger.IsAttached)
                {
                    System.Console.WriteLine("Debugger 启用成功" + StackTraceHelper.AtLine());
                    Debug.WriteLine("This is a test log message raised in the System.Diagnostics.Debug tests for the .NET Debugger class.", "category");
                    return;
                }
            }
            else
                // 校验
                Console.WriteLine("Debugger 已启用" + StackTraceHelper.AtLine());

        }

        /// <summary>
        /// 发送消息到连接的调试器输出
        /// </summary>
        public void LogTest()
        {
            if (Debugger.IsLogging())
                Debugger.Log(1, "Debug Log", "Loggggggggggggggggggggggggggggggggggggggggggggggg.");
            else
                Console.WriteLine(Debugger.IsAttached ? "Debugger 未启用" : "Debugger 未启用日志记录" + StackTraceHelper.AtLine());
        }

        /// <summary>
        /// 通知调试器执行即将进入一个涉及跨线程依赖项的路径
        /// <br>未知</br>
        /// </summary>
        public void NotifyOfCrossThreadDependencyTest()
        {
            Debugger.NotifyOfCrossThreadDependency(); // ??
        }
    }
}
