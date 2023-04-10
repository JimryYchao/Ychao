using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Xml.Serialization;
using Ychao.Diagnostics.Exceptions;

namespace Ychao.Diagnostics
{
    public delegate void OnAssertFailed();

    public sealed class CodeDebug
    {
        static bool IsFirstDebug = true;

        /// <summary>
        /// Debug 重定向
        /// </summary>
        private static volatile IDebugProvider s_provider = new CodeDebugProvider();

        public static bool AutoFlush { get => s_provider.FlashFrequency < 2; }

        public static void SetFlushFrequency(int frequency) => s_provider.FlashFrequency = frequency;

        public static IDebugProvider SetDebugProvider(IDebugProvider provider)
        {
            if (provider == null)
                throw ThrowHelper.ArgumentNullException(nameof(provider));
            return Interlocked.Exchange(ref s_provider, provider);
        }

        public enum MessageCategory
        {
            None = -1,
            INFO,
            DEBUG,
            WARNING,
            ERROR,
            EXCEPTION,
        }

        [Conditional("DEBUG")]
        static void __StartDebug()
        {
            if (IsFirstDebug)
            {
                Debug.AutoFlush = true;
                IsFirstDebug = false;
                s_provider.WriteLine("============ DEBUG LOG BEGINNING =============");
            }
            s_provider.WriteLine(" ");
        }

        [Conditional("DEBUG")]
        static void __WriteLine(string message, MessageCategory category)
        {
            if (string.IsNullOrEmpty(message))
                return;
            __StartDebug();
            s_provider.WriteLine((category != MessageCategory.None ? category + " : " : "") + message, 1);
        }

        [Conditional("DEBUG")]
        public static void WriteLineIf(bool condition, string message, MessageCategory category = MessageCategory.None)
        {
            if (condition)
                __WriteLine(message, category);
        }

        [Conditional("DEBUG")]
        public static void WhiteLine(string message, MessageCategory category = MessageCategory.None)
        {
            __WriteLine(message, category);
        }


        [DoesNotReturn, Conditional("DEBUG")]
        public static void Fail(string message, MessageCategory category = MessageCategory.None)
        {
            Fail(message, string.Empty, category);
        }

        /// <summary>
        /// Trace Core 
        /// </summary>
        [DoesNotReturn, Conditional("DEBUG")]
        public static void Fail(string message, string detail, MessageCategory category = MessageCategory.None)
        {
            if (!string.IsNullOrEmpty(message?.ToString()))
            {
                __StartDebug();
                string stackTrace;
                try
                {
                    stackTrace = new StackTrace(2, true).ToString();
                }
                catch
                {
                    stackTrace = "";
                }

                s_provider.Fail((category != MessageCategory.None ? category + " : " : "") + message.ToString(), detail);
                if (string.IsNullOrEmpty(stackTrace))
                    s_provider.WriteLine(stackTrace, 2);
            }
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition)
        {
            Assert(condition, string.Empty, string.Empty);
        }
        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, OnAssertFailed onFaild)
        {
            Assert(condition, string.Empty, string.Empty, onFaild);
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, string message, MessageCategory category = MessageCategory.None)
        {
            Assert(condition, message, string.Empty, null);
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, string message, string detail, MessageCategory category = MessageCategory.None)
        {
            Assert(condition, message, detail, null);
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, string message, string detail, OnAssertFailed onFaild, MessageCategory category = MessageCategory.None)
        {
            if (condition) return;
            onFaild?.Invoke();
            Fail(message, detail, category);
        }
    }
}



