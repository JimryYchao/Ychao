using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Ychao.Diagnostics
{
    public delegate void OnAssertFailed();

    public sealed class CodeDebug
    {
        static bool IsFirstDebug = true;

        /// <summary>
        /// Debug 版本允许重定向
        /// </summary>
        [ThreadStatic]
        private static volatile IDebugProvider s_provider = new CodeDebugProvider(Thread.CurrentThread.ManagedThreadId);

        ///// <summary>
        ///// 小于 2 表示 Debug.AutoFlush
        ///// </summary>
        //[Conditional("DEBUG")]
        //public static void SetFlushFrequency(int frequency) => s_provider.FlashFrequency = frequency;

        public static IDebugProvider SetDebugProvider(IDebugProvider provider)
        {
            if (provider == null)
                throw ThrowHelper.ArgumentNullException(nameof(provider));
            return Interlocked.Exchange(ref s_provider, provider);
        }

        public enum MessageCategory
        {
            DEBUG = 0,
            INFO,
            WARNING,
            ERROR,
            EXCEPTION,
        }
        static void __OnlyCodeTrace()
        {
            __StartDebug();
            s_provider.WriteLine("> " + DateTime.Now.ToString());
            s_provider.WriteLine("CODE TRACE:");
            s_provider.PrintStackTraceDetail(4);
        }


        [Conditional("DEBUG")]
        static void __StartDebug()
        {
            if (IsFirstDebug)
            {
                IsFirstDebug = false;
                s_provider.WriteLine("# ============= DEBUG LOG BEGINNING =============");
                return;
            }
            s_provider.WriteLine(" ");
        }

        [Conditional("DEBUG")]
        static void __WriteLine(string message, MessageCategory category, bool stackTraceable)
        {
            if (string.IsNullOrEmpty(message) && stackTraceable)
                __OnlyCodeTrace();
            else
            if (!string.IsNullOrEmpty(message?.ToString()))
            {
                __StartDebug();

                s_provider.WriteLine("> " + DateTime.Now.ToString());
                s_provider.WriteLine((category + " : ") + message);
                if (stackTraceable)
                    s_provider.PrintStackTraceDetail(3);
            }
        }

        [Conditional("DEBUG")]
        public static void WriteLineIf(bool condition, string message, MessageCategory category = MessageCategory.DEBUG, bool stackTraceable = false)
        {
            if (condition)
                __WriteLine(message, category, stackTraceable);
        }

        [Conditional("DEBUG")]
        public static void WriteLine(string message, MessageCategory category = MessageCategory.DEBUG, bool stackTraceable = false)
        {
            __WriteLine(message, category, stackTraceable);
        }

        /// <summary>
        /// Debug Core 
        /// </summary>
        [Conditional("DEBUG")]
        static void __Fail(string message, MessageCategory category = MessageCategory.DEBUG, bool stackTraceable = false)
        {
            if (string.IsNullOrEmpty(message) && stackTraceable)
            {
                __OnlyCodeTrace();
            }
            else
            if (!string.IsNullOrEmpty(message?.ToString()))
            {
                __StartDebug();

                s_provider.WriteLine("> " + DateTime.Now.ToString());
                s_provider.Fail((category + " : ") + message.ToString());
                if (stackTraceable)
                    s_provider.PrintStackTraceDetail(3);
            }
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, bool stackTraceable = false)
        {
            if (!condition)
                __Fail(string.Empty, MessageCategory.DEBUG, stackTraceable);

        }
        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, OnAssertFailed onFaild, bool stackTraceable = false)
        {
            if (!condition)
            {
                onFaild?.Invoke();
                __Fail(string.Empty, MessageCategory.DEBUG, stackTraceable);
            }
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, string message, MessageCategory category = MessageCategory.DEBUG, bool stackTraceable = false)
        {
            if (!condition)
                __Fail(message, category, stackTraceable);
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, string message, OnAssertFailed onFaild, MessageCategory category = MessageCategory.DEBUG, bool stackTraceable = false)
        {
            if (!condition)
            {
                onFaild?.Invoke();
                __Fail(message, category, stackTraceable);
            }
        }
    }
}