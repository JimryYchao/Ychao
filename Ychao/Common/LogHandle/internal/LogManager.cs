using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Ychao.Logs;

namespace Ychao
{
    // Global LogManager Instance
    public sealed class LogManager
    {
        internal static DateTime TimeStamp => DateTime.Now;

        static LogManager()
        {
            GlobalMode = LogMode.All;
        }

        public static LogMode GlobalMode { get; set; }

        internal readonly static ILogger defaultLogger = new Inline_Logger();
        class Inline_Logger : ILogger
        {
            private int InstanceId = -1;
            public Inline_Logger()
            {
                LoggerCollecter.AddLogger(new WeakReference<ILogger>(this), ref InstanceId);
                LogHandler = Logs.LogHandler.Handler;
                LogMode = LogMode.All;
                LogEnabled = true;
            }

            public ILogHandle LogHandler { get; set; }
            public LogMode LogMode { get; set; }
            public bool LogEnabled { get; set; }

            public void Debug(object message)
            {
                if (LogEnabled && (LogMode & LogMode.Debug) > 0)
                    LogHandler.Log(LogMode.Debug, string.Format(ILogger.DebugFormat, TimeStamp, message));
            }

            public void Debug(string format, params object[] args)
            {
                object message = string.Format(format, args);
                Debug(message);
            }

            public void Error(object message)
            {
                if (LogEnabled && (LogMode & LogMode.Error) > 0)
                    LogHandler.Log(LogMode.Error, string.Format(ILogger.ErrorFormat, TimeStamp, message));
            }

            public void Error(string format, params object[] args)
            {
                object message = string.Format(format, args);
                Error(message);
            }

            public void Exception(Exception exception, object message)
            {
                if (LogEnabled && (LogMode & LogMode.Exception) > 0)
                    LogHandler.LogException(LogMode.Exception, exception, string.Format(ILogger.ExceptionFormat, TimeStamp, message));
            }

            public void Exception(Exception exception, string format, params object[] args)
            {
                object message = string.Format(format, args);
                Exception(exception, message);
            }


            [DoesNotReturn]
            public void Fatal(Exception exception, object message)
            {
                if (LogEnabled && (LogMode & LogMode.Fatal) > 0)
                    LogHandler.LogException(LogMode.Fatal, exception, string.Format(ILogger.FatalFormat, TimeStamp, message));
                // 可能有退出的代码
            }

            [DoesNotReturn]
            public void Fatal(Exception exception, string format, params object[] args)
            {
                object message = string.Format(format, args);
                Fatal(exception, message);
            }

            public void Info(object message)
            {
                if (LogEnabled && (LogMode & LogMode.Info) > 0)
                    LogHandler.Log(LogMode.Info, string.Format(ILogger.InfoFormat, TimeStamp, message));
            }

            public void Info(string format, params object[] args)
            {
                object message = string.Format(format, args);
                Info(message);
            }

            public void Warning(object message)
            {
                if (LogEnabled && (LogMode & LogMode.Warning) > 0)
                    LogHandler.Log(LogMode.Warning, string.Format(ILogger.WarningFormat, TimeStamp, message));
            }

            public void Warning(string format, params object[] args)
            {
                object message = string.Format(format, args);
                Warning(message);
            }

            void CheckArrayNull(ref object[] args)
            {
                if(args == null)
                    args = new object[0] { };
            }
        }
    }

    public enum LogMode
    {
        NoLog = 0,

        Debug = 1,
        Info = 1 << 1,
        Warning = 1 << 2,


        Error = 1 << 10,
        Exception = 1 << 11,
        Fatal = 1 << 12,

        All = Debug | Info | Warning | Error | Exception | Fatal
    }
}
