namespace Ychao.Logs
{
    public interface ILogger
    {
        internal const string INFO = "[{0}][INFO]: {1}";
        internal const string DEBUG = "[{0}][DEBUG]: {1}";
        internal const string WARNING = "[{0}][WARNING]: {1}";
        internal const string ERROR = "[{0}][ERROR]: {1}";
        internal const string EXCEPTION = "[{0}][EXCEPTION]: {1}";
        internal const string FATAL = "[{0}][FATAL]: {1}";

        ILogHandle LogHandler { get; set; }

        LogMode LogMode { get; set; }

        bool LogEnabled { get; set; }

        void Info(object message);

        void InfoFormat(string format, params object[] args);

        void Debug(object message);

        void DebugFormat(string format, params object[] args);

        void Warning(object message);
        
        void WarningFormat(string format, params object[] args);

        void Error(object message);
        
        void ErrorFormat(string format, params object[] args);

        void Exception(System.Exception exception, object message);
        
        void ExceptionFormat(System.Exception exception, string format, params object[] args);

        void Fatal(System.Exception exception, object message);
        
        void FatalFormat(System.Exception exception, string format, params object[] args);
    }
}
