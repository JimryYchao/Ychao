using Ychao.Logs;

namespace Ychao
{
    public sealed class LogAddition

    {
        public static void DebugAll(object message)
        {
            foreach (var item in LoggerCollecter.loggers.Values)
            {
                if (item.TryGetTarget(out ILogger logger))
                    logger.Debug(message);
            }
        }

        public static void InfoAll(object message)
        {
            foreach (var item in LoggerCollecter.loggers.Values)
            {
                if (item.TryGetTarget(out ILogger logger))
                    logger.Info(message);
            }
        }

        public static void WarningAll(object message)
        {
            foreach (var item in LoggerCollecter.loggers.Values)
            {
                if (item.TryGetTarget(out ILogger logger))
                    logger.Warning(message);
            }
        }

        public static void ErrorAll(object message)
        {
            foreach (var item in LoggerCollecter.loggers.Values)
            {
                if (item.TryGetTarget(out ILogger logger))
                    logger.Error(message);
            }
        }

        public static void FatalAll(System.Exception exception, object message)
        {
            foreach (var item in LoggerCollecter.loggers.Values)
            {
                if (item.TryGetTarget(out ILogger logger))
                    logger.Fatal(exception, message);
            }
        }

        public static void ExceptionAll(System.Exception exception, object message)
        {
            foreach (var item in LoggerCollecter.loggers.Values)
            {
                if (item.TryGetTarget(out ILogger logger))
                    logger.Exception(exception, message);
            }
        }
    }
}
