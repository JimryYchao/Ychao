using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Ychao.Diagnostics
{
    public delegate void OnAssertFailed();

    public enum MessageCategory
    {
        DEBUG = 0,
        INFO,
        WARNING,
        ERROR,
        EXCEPTION,
    }

    public sealed class CodeDebug
    {
        internal static volatile ICodeTraceProvider s_provider = new CodeDebugProvider(true);

        public static ICodeTraceProvider SetDebugProvider(ICodeTraceProvider provider)
        {
            if (provider == null)
                throw ThrowHelper.ArgumentNullException(nameof(provider));
            return Interlocked.Exchange(ref s_provider, provider);
        }

        public static void SetDebugFilePath(string path)
        {
            CodeTraceWritter.OutDirectoryPath = path;
        }

        public static void BeginWriteToFile() => CodeTraceWritter.BeginWriteThread();

        public static void StopWriteToFile() => CodeTraceWritter.StopWriteThread();

        [Conditional("DEBUG")]
        public static void WriteLineIf(bool condition, string message, MessageCategory category = MessageCategory.DEBUG, bool stackTraceable = false)
        {
            if (condition)
                CodeTraceWritter.WriteLine(s_provider, message, category, stackTraceable ? new StackTrace(1) : null);
        }

        [Conditional("DEBUG")]
        public static void WriteLine(string message, MessageCategory category = MessageCategory.DEBUG, bool stackTraceable = false)
        {
            CodeTraceWritter.WriteLine(s_provider, message, category, stackTraceable ? new StackTrace(1) : null);
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, bool stackTraceable = false)
        {
            if (!condition)
                CodeTraceWritter.Fail(s_provider, string.Empty, stackTraceable ? new StackTrace(1) : null);

        }
        [Conditional("DEBUG")]
        public static void Assert(OnAssertFailed onFaild, [DoesNotReturnIf(false)] bool condition, bool stackTraceable = false)
        {
            if (!condition)
            {
                onFaild?.Invoke();
                CodeTraceWritter.Fail(s_provider, string.Empty, stackTraceable ? new StackTrace(1) : null);
            }
        }

        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, string message, bool stackTraceable = false)
        {
            if (!condition)
                CodeTraceWritter.Fail(s_provider, message, stackTraceable ? new StackTrace(1) : null);
        }

        [Conditional("DEBUG")]
        public static void Assert(OnAssertFailed onFaild, [DoesNotReturnIf(false)] bool condition, string message, bool stackTraceable = false)
        {
            if (!condition)
            {
                onFaild?.Invoke();
                CodeTraceWritter.Fail(s_provider, message, stackTraceable ? new StackTrace(1) : null);
            }
        }
    }
}