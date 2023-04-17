using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Ychao.Diagnostics;

namespace Ychao.Diagnostics
{
    internal static class CodeTraceWriter
    {
        private static volatile int s_OnWritting = -1;
        private static volatile int CanDebugToFile = -1;
        private static Thread writeThread;
        private static Queue<Action> s_CodeDebugActions = new Queue<Action>();

        private static string defaultOutPath => Environment.CurrentDirectory + "\\Logs\\";
        internal static bool OnWritting => s_OnWritting > 0;
        internal static string OutDirectoryPath { get; set; }

        internal static bool BeginWriteThread()
        {
            return Interlocked.Exchange(ref CanDebugToFile, 1) > 0;
        }
        internal static bool StopWriteThread()
        {
            return Interlocked.Exchange(ref CanDebugToFile, -1) < 0;
        }

        internal static void WriteLine(ITraceWriterProvider provider, string message, MessageCategory category, StackTrace? trace)
        {
            if (provider == null)
                return;

            if (CanDebugToFile > 0 && provider.CanWriteToFile)
            {
                if (s_OnWritting < 0)
                {
                    Interlocked.Exchange(ref s_OnWritting, 1);
                    writeThread = new Thread(WriteThread);
                    writeThread.Start();
                }
                s_CodeDebugActions.Enqueue(() => provider.WriteLine(message, category, trace));
            }
            else
                provider.WriteLine(message, category, trace);
        }
        internal static void Fail(ITraceWriterProvider provider, string message, StackTrace? trace)
        {
            if (CanDebugToFile > 0 && provider.CanWriteToFile)
            {
                if (s_OnWritting < 0)
                {
                    Interlocked.Exchange(ref s_OnWritting, 1);
                    writeThread = new Thread(WriteThread);
                    writeThread.Start();
                }
                s_CodeDebugActions.Enqueue(() => provider.Fail(message, trace));
            }
            else
                provider.Fail(message, trace);
        }

        private static void WriteThread()
        {
            string path = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(OutDirectoryPath) && !Directory.Exists(OutDirectoryPath))
                    Directory.CreateDirectory(OutDirectoryPath);
                else
                {
                    if (!Directory.Exists(defaultOutPath))
                        Directory.CreateDirectory(defaultOutPath);
                }
            }
            catch
            {
                OutDirectoryPath = string.Empty;
                if (!Directory.Exists(defaultOutPath))
                    Directory.CreateDirectory(defaultOutPath);
            }

            float time = 1000;
            FileStream fs = null;
            TextWriterTraceListener tracer = null;
            try
            {
                fs = new FileStream((OutDirectoryPath != null ? OutDirectoryPath : defaultOutPath) + $"Log_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                Trace.Listeners.Add(tracer = new TextWriterTraceListener(fs));
                while (true)
                {
                    if (s_CodeDebugActions.Count > 0)
                    {
                        var ac = s_CodeDebugActions.Dequeue();
                        ac?.Invoke();
                        time = 1000;
                        Trace.Flush();
                        continue;
                    }
                    else
                    {
                        Thread.Sleep(100);
                        time -= 100;
                        if (time < 0)
                            break;
                        continue;
                    }
                }
            }
            finally
            {
                fs?.Close();
                Trace.Listeners.Remove(tracer);
                tracer?.Close();
                Trace.Close();
            }
            Interlocked.Exchange(ref s_OnWritting, -1);
        }
    }
}
