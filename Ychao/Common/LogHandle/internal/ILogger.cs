namespace Ychao.Logs
{
    public interface ILogger
    {
        internal const string InfoFormat = "[{0}][INFO]: {1}";
        internal const string DebugFormat = "[{0}][DEBUG]: {1}";
        internal const string WarningFormat = "[{0}][WARNING]: {1}";
        internal const string ErrorFormat = "[{0}][ERROR]: {1}";
        internal const string ExceptionFormat = "[{0}][EXCEPTION]: {1}";
        internal const string FatalFormat = "[{0}][FATAL]: {1}";

        ILogHandle LogHandler { get; set; }

        LogMode LogMode { get; set; }

        bool LogEnabled { get; set; }

        void Info(object message);

        void Info(string format, params object[] args);

        void Debug(object message);

        void Debug(string format, params object[] args);

        void Warning(object message);
        
        void Warning(string format, params object[] args);

        void Error(object message);
        
        void Error(string format, params object[] args);

        void Exception(System.Exception exception, object message);
        
        void Exception(System.Exception exception, string format, params object[] args);

        void Fatal(System.Exception exception, object message);
        
        void Fatal(System.Exception exception, string format, params object[] args);
    }
}
