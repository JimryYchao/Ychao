using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
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
            s_provider.WriteLine($"Timestamp >>> {System.DateTime.Now.ToString()}");
        }

        [Conditional("DEBUG")]
        static void __WriteLine(string message, MessageCategory category)
        {
            if (string.IsNullOrEmpty(message))
                return;
            __StartDebug();
            s_provider.WriteLine((category != MessageCategory.None ? category + " : " : "") + message);
        }

        [Conditional("DEBUG")]
        public static void WriteLineIf(bool condition, string message, MessageCategory category = MessageCategory.None)
        {
            if (condition)
            {
                __StartDebug();
                __WriteLine(message, category);
            }
        }

        [DoesNotReturn, Conditional("DEBUG")]
        public static void Fail(string message, MessageCategory category = MessageCategory.None)
        {
            Fail(message, null, category);
        }

        [DoesNotReturn, Conditional("DEBUG")]
        public static void Fail(string message, string detail, MessageCategory category = MessageCategory.None)
        {
            if (string.IsNullOrEmpty(message?.ToString()))
                return;
            __StartDebug();
            s_provider.Fail((category != MessageCategory.None ? category + " : " : "") + message.ToString(), detail);
            Debug.Fail(null, null);
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition)
        {

        }


        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, string message, MessageCategory category = MessageCategory.None)
        {

        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, string message, string detail, MessageCategory category = MessageCategory.None)
        {

        }


        public static void Assert([DoesNotReturnIf(false)] bool condition, string message, OnAssertFailed onFaild, MessageCategory category = MessageCategory.None)
        {
            if (condition) return;
            
            
            __StartDebug();



            onFaild?.Invoke();
        }

    }
}



