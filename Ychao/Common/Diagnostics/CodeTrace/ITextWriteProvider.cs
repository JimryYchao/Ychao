using System.Diagnostics;

namespace Ychao.Diagnostics
{
    public interface ITextWriteProvider
    {
        void WriteLine(string message, MessageCategory category, StackTrace? trace);
        void Fail(string message, StackTrace? trace);
        bool CanWriteToFile { get; }

        bool AutoFlush { get; set; }

        protected static string GetCategory(MessageCategory category)
        {
            return category switch
            {
                MessageCategory.INFO => "INFO",
                MessageCategory.WARNING => "WARNING",
                MessageCategory.ERROR => "ERROR",
                MessageCategory.EXCEPTION => "EXCEPTION",

                _ => "DEBUG",
            };
        }
    }
}
