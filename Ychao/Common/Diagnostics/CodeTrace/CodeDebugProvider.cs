using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Ychao.Diagnostics;

namespace Ychao.Diagnostics
{
    internal class CodeDebugProvider : ITraceWriterProvider
    {
        public CodeDebugProvider(bool canWriteToFile)
        {
            this.CanWriteToFile = canWriteToFile;
        }

        public bool CanWriteToFile { get; }
        public bool AutoFlush { get => Debug.AutoFlush; set => Debug.AutoFlush = value; }

        private string StackTraceDetail(StackTrace? trace)
        {
            string stack = trace?.ToString();

            if (!string.IsNullOrEmpty(stack))
            {
                StringBuilder sb = new StringBuilder("");
                using (StringReader sr = new StringReader(stack))
                {
                    string line = string.Empty;
                    while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                        sb.AppendLine($"\t\t{line}");
                    return sb.ToString();
                }
            }
            else
                return string.Empty;
        }

        protected virtual void WriteCore(string message, MessageCategory category)
        {
            Debug.WriteLine(message);

            if (AutoFlush)
                Debug.Flush();
        }

        public void WriteLine(string message, MessageCategory category, StackTrace? trace)
        {
            var time = DateTime.Now;
            var msg = string.IsNullOrEmpty(message) ? "STACKTRACE" : message;
            WriteCore($"[{time}.{time.Millisecond}][{Thread.CurrentThread.ManagedThreadId}][{ITraceWriterProvider.GetCategory(category)}] : {msg}" +
                $"{StackTraceDetail(trace)}",
                category);
        }

        public void Fail(string message, StackTrace? trace)
        {
            WriteLine($"[ASSERT FAILED] {message}", MessageCategory.WARNING, trace);
        }
    }
}
