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
                    return m_Logger = LogManager.defaultLogger;
                return m_Logger;
            }
        }


        public static ILogHandle LogCore
        {
            private get => _Logger == null ? LogManager.defaultLogger.LogHandler : _Logger.LogHandler;
            set => m_Logger = new Logger(value, LogMode.All, true);
        }

        public static bool LogEnabled { get => _Logger.LogEnabled; set => _Logger.LogEnabled = value; }

        public static LogMode GlobalLogType { get => LogManager.GlobalMode; set => LogManager.GlobalMode = value; }

        public static LogMode BindingLoggerType { get => _Logger.LogMode; set => _Logger.LogMode = value; }

        public static void Debug(object message) => _Logger.Debug(message);

        public static void Debug(string format, params object[] args) => _Logger.Debug(format, args);

        public static void Info(object message) => _Logger.Info(message);

        public static void Info(string format, params object[] args) => _Logger.Info(format, args);

        public static void Warning(object message) => _Logger.Warning(message);

        public static void Warning(string format, params object[] args) => _Logger.Warning(format, args);

        public static void Error(object message) => _Logger.Error(message);

        public static void Error(string format, params object[] args) => _Logger.Error(format, args);

        public static void Exception(System.Exception exception, object message) => _Logger.Exception(exception, message);

        public static void Exception(System.Exception exception, string format, params object[] args) => _Logger.Exception(exception, format, args);

        public static void Fatal(System.Exception exception, object message) => _Logger.Fatal(exception, message);

        public static void Fatal(System.Exception exception, string format, params object[] atrgs) => _Logger.Fatal(exception, format, atrgs);
    }
}
