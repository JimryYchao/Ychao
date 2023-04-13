using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Threading;

namespace Ychao.Diagnostics
{
    public sealed class CodeTrace
    {
        internal static volatile ITextWriteProvider s_provider = new CodeTraceProvider(true);

        public static ITextWriteProvider SetDebugProvider(ITextWriteProvider provider)
        {
            if (provider == null)
                throw ThrowHelper.ArgumentNullException(nameof(provider));
            return Interlocked.Exchange(ref s_provider, provider);
        }

        public static void SetDebugFilePath(string path)
        {
            CodeTraceWriter.OutDirectoryPath = path;
        }

        /// <summary>
        /// 是否需要跟踪到输出文件信息
        /// </summary>
        public static bool TrackNeedFileInfo { get; set; }

        public static bool AutoFlush { get; set; }

        public static void BeginWriteToFile() => CodeTraceWriter.BeginWriteThread();

        public static void StopWriteToFile() => CodeTraceWriter.StopWriteThread();

        [Conditional("TRACE")]
        public static void WriteLineIf(bool condition, string message, MessageCategory category = MessageCategory.DEBUG, bool stackTraceable = false)
        {
            if (condition)
                CodeTraceWriter.WriteLine(s_provider, message, category, stackTraceable ? new StackTrace(1, TrackNeedFileInfo) : null);
        }

        [Conditional("TRACE")]
        public static void WriteLine(string message, MessageCategory category = MessageCategory.DEBUG, bool stackTraceable = false)
        {
            CodeTraceWriter.WriteLine(s_provider, message, category, stackTraceable ? new StackTrace(1, TrackNeedFileInfo) : null);
        }

        [Conditional("TRACE")]
        public static void Assert(bool condition, bool stackTraceable = false)
        {
            if (!condition)
                CodeTraceWriter.Fail(s_provider, string.Empty, stackTraceable ? new StackTrace(1, TrackNeedFileInfo) : null);

        }
        [Conditional("TRACE")]
        public static void Assert(OnAssertFailed onFaild, bool condition, bool stackTraceable = false)
        {
            if (!condition)
            {
                onFaild?.Invoke();
                CodeTraceWriter.Fail(s_provider, string.Empty, stackTraceable ? new StackTrace(1, TrackNeedFileInfo) : null);
            }
        }

        [Conditional("TRACE")]
        public static void Assert(bool condition, string message, bool stackTraceable = false)
        {
            if (!condition)
                CodeTraceWriter.Fail(s_provider, message, stackTraceable ? new StackTrace(1, TrackNeedFileInfo) : null);
        }

        [Conditional("TRACE")]
        public static void Assert(OnAssertFailed onFaild, bool condition, string message, bool stackTraceable = false)
        {
            if (!condition)
            {
                onFaild?.Invoke();
                CodeTraceWriter.Fail(s_provider, message, stackTraceable ? new StackTrace(1,TrackNeedFileInfo) : null);
            }
        }
    }
}
