using System.Diagnostics;

namespace Ychao.Diagnostics
{
    public interface ICodeTraceProvider
    {
        void WriteLine(string message, MessageCategory category, StackTrace? trace);
        void Fail(string message, StackTrace? trace);
        bool CanWriteToFile { get; }
    }
}
