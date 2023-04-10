using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Ychao.Attributes;

namespace Ychao.Logs
{
    [CannotDispose]
    internal sealed class Logger : ILogger
    {
        private int InstanceId = -1;
        internal ILogHandle BindingsLogger { get; private set; }
        public ILogHandle LogHandler { get; set; }
        public LogMode LogMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool LogEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        internal Logger(ILogHandle handler, LogMode mode, bool logEnabled)
        {
            this.LogHandler = handler;
            this.LogMode = mode;
            this.LogEnabled = logEnabled;

            LoggerCollecter.AddLogger(new WeakReference<ILogger>(this), ref InstanceId);
        }

        bool CheckGlobalMode(LogMode mode)
        {
            return (mode & LogManager.GlobalMode) > 0;
        }

        public void Info(object message)
        {
            if (!CheckGlobalMode(LogMode.Info))
                return;
            if (LogEnabled && (this.LogMode & LogMode.Info) > 0)
                LogHandler.Log(LogMode.Info, string.Format(ILogger.InfoFormat, LogManager.TimeStamp, message));
        }

        public void Debug(object message)
        {
            if (!CheckGlobalMode(LogMode.Debug))
                return;
            if (LogEnabled && (LogMode & LogMode.Debug) > 0)
                LogHandler.Log(LogMode.Debug, string.Format(ILogger.DebugFormat, LogManager.TimeStamp, message));

        }

        public void Warning(object message)
        {
            if (!CheckGlobalMode(LogMode.Warning))
                return;
            if (LogEnabled && (LogMode & LogMode.Warning) > 0)
                LogHandler.Log(LogMode.Warning, string.Format(ILogger.WarningFormat, LogManager.TimeStamp, message));
        }

        public void Error(object message)
        {
            if (!CheckGlobalMode(LogMode.Error))
                return;
            if (LogEnabled && (LogMode & LogMode.Error) > 0)
                LogHandler.Log(LogMode.Error, string.Format(ILogger.ErrorFormat, LogManager.TimeStamp, message));
        }

        public void Exception(Exception exception, object message)
        {
            if (!CheckGlobalMode(LogMode.Exception))
                return;
            if (LogEnabled && (LogMode & LogMode.Exception) > 0)
                LogHandler.LogException(LogMode.Exception, exception, string.Format(ILogger.ExceptionFormat, LogManager.TimeStamp, message));
        }

        [DoesNotReturn]
        public void Fatal(Exception exception, object message)
        {
            if (!CheckGlobalMode(LogMode.Fatal))
                return;
            if (LogEnabled && (LogMode & LogMode.Fatal) > 0)
                LogHandler.LogException(LogMode.Fatal, exception, string.Format(ILogger.FatalFormat, LogManager.TimeStamp, message));
        }


        public void Info(string format, params object[] args)
        {
            if (!CheckGlobalMode(LogMode.Info))
                return;
            if (LogEnabled && (LogMode & LogMode.Info) > 0)
            {
                object message = string.Format(format, args);
                Info(message);
            }
        }

        public void Debug(string format, params object[] args)
        {
            if (!CheckGlobalMode(LogMode.Debug))
                return;
            if (LogEnabled && (LogMode & LogMode.Debug) > 0)
            {
                object message = string.Format(format, args);
                Debug(message);
            }
        }

        public void Warning(string format, params object[] args)
        {
            if (!CheckGlobalMode(LogMode.Warning))
                return;

            if (LogEnabled && (LogMode & LogMode.Warning) > 0)
            {
                object message = string.Format(format, args);
                Warning(message);
            }
        }

        public void Error(string format, params object[] args)
        {
            if (!CheckGlobalMode(LogMode.Error))
                return;
            if (LogEnabled && (LogMode & LogMode.Error) > 0)
            {
                object message = string.Format(format, args);
                Error(message);
            }
        }

        public void Exception(Exception exception, string format, params object[] args)
        {
            if (!CheckGlobalMode(LogMode.Exception))
                return;
            if (LogEnabled && (LogMode & LogMode.Exception) > 0)
            {
                object message = string.Format(format, args);
                Exception(exception, message);
            }
        }

        [DoesNotReturn]
        public void Fatal(Exception exception, string format, params object[] args)
        {
            if (!CheckGlobalMode(LogMode.Fatal))
                return;
            if (LogEnabled && (LogMode & LogMode.Fatal) > 0)
            {
                object message = string.Format(format, args);
                Fatal(exception, message);
            }
        }


        ~Logger()
        {
            LoggerCollecter.DeleteLogger(InstanceId);
            System.Console.WriteLine($"Logger[ID:{InstanceId}] was deleted...");
        }
    }
}
