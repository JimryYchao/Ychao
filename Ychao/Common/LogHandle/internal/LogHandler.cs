using System;

namespace Ychao.Logs
{
    public sealed class LogHandler : ILogHandle
    {
        internal readonly static LogHandler Handler = new LogHandler();

        public void Log(LogMode logType, object message)
        {
            // 是否需要跳出 控制窗
            if (LogSystem.AllowOutput)
            {
                //LogOutput.
                //ISingleton<LogCollecter>.Singleton.EnLog(message);
                return;
            }
            Console.Out.WriteLine(message);
        }

        public void LogException(LogMode logType, Exception exception, object message)
        {
            throw new Exception(message == null ? string.Empty : message.ToString(), exception);
        }
    }
}
