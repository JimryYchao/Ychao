namespace Ychao.Logs
{
    public interface ILogHandle
    {
        void Log(LogMode mode, object message);

        void LogException(LogMode mode, System.Exception exception, object message);
    }
}
