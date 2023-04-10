using System;
using System.Collections.Generic;

namespace Ychao.Logs
{
    internal sealed class LoggerCollecter
    {
        static LoggerCollecter()
        {
            loggers = new Dictionary<int, WeakReference<ILogger>>();
        }

        internal static Dictionary<int, WeakReference<ILogger>> loggers;

        static int m_CurLoggerInstanceID = 0;

        internal static void AddLogger(WeakReference<ILogger> logger, ref int id)
        {
            id = ++m_CurLoggerInstanceID;
            loggers.Add(id, logger);
        }

        internal static void DeleteLogger(int instanceId)
        {
            loggers.Remove(instanceId);
        }

        internal void DisposeInvalidLoggers()
        {
            GC.Collect();
        }
    }
}
