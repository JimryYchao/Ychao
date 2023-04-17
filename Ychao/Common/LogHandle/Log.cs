using Ychao.Logs;

namespace Ychao
{
    public sealed class Log
    {
        private static ILogger m_Logger;
        private static ILogger _Logger
        {
            get
            {
                if (m_Logger == null)
                    return m_Logger = LogSystem.defaultLogger;
                return m_Logger;
            }
        }

        public static ILogHandle LogCore
        {
            private get => _Logger == null ? LogSystem.defaultLogger.LogHandler : _Logger.LogHandler;
            set => m_Logger = new Logger(value, LogMode.All, true);
        }

        public static void Print(string message)
        {
            LogCore.Log(LogMode.Info, message);
        }

        public static bool LogEnabled { get => _Logger.LogEnabled; set => _Logger.LogEnabled = value; }

        public static LogMode GlobalLogType { get => LogSystem.GlobalMode; set => LogSystem.GlobalMode = value; }

        public static LogMode BindingLoggerType { get => _Logger.LogMode; set => _Logger.LogMode = value; }

        public static void Debug(object message) => _Logger.Debug(message);

        public static void DebugFormat(string format, params object[] args) => _Logger.DebugFormat(format, args);

        public static void Info(object message) => _Logger.Info(message);

        public static void InfoFormat(string format, params object[] args) => _Logger.InfoFormat(format, args);

        public static void Warning(object message) => _Logger.Warning(message);

        public static void WarningFormat(string format, params object[] args) => _Logger.WarningFormat(format, args);

        public static void Error(object message) => _Logger.Error(message);

        public static void ErrorFormat(string format, params object[] args) => _Logger.ErrorFormat(format, args);

        public static void Exception(System.Exception exception, object message) => _Logger.Exception(exception, message);

        public static void ExceptionFormat(System.Exception exception, string format, params object[] args) => _Logger.ExceptionFormat(exception, format, args);

        public static void Fatal(System.Exception exception, object message) => _Logger.Fatal(exception, message);

        public static void FatalFormat(System.Exception exception, string format, params object[] atrgs) => _Logger.FatalFormat(exception, format, atrgs);
    }
}
