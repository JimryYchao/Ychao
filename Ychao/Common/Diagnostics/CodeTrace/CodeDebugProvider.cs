using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Ychao.Diagnostics
{
    internal class CodeDebugProvider : ICodeTraceProvider
    {
        public CodeDebugProvider(bool texted)
        {
            CanWriteToFile = texted;
        }

        public bool CanWriteToFile { get; }

        string GetCategory(MessageCategory category)
        {
            return category switch
            {
                MessageCategory.INFO => "INFO",
                MessageCategory.WARNING => "WARNING",
                MessageCategory.ERROR => "ERROR",
                MessageCategory.EXCEPTION => "EXCEPTION",

                _ => "DEBUG",
            };
        }

        void PrintStackTraceDetail(StackTrace? trace)
        {
            if (trace == null)
                return;
            string stack = trace.ToString();

            if (!string.IsNullOrEmpty(stack))
            {
                using (StringReader sr = new StringReader(stack))
                {
                    string line = string.Empty;
                    while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                        Debug.WriteLine("\t\t" + line);
                }
            }
        }

        public void WriteLine(string message, MessageCategory category, StackTrace? trace)
        {
            var msg = string.IsNullOrEmpty(message) ? "STACKTRACE" : message;
            Debug.WriteLine($"[{DateTime.Now}][{Thread.CurrentThread.ManagedThreadId}][{GetCategory(category)}] : {msg}");
            PrintStackTraceDetail(trace);
        }

        public void Fail(string message, StackTrace? trace)
        {
            WriteLine($"[ASSERT FAILED] {message}", MessageCategory.WARNING, trace);
        }
    }
}
