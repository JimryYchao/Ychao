using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace Ychao.Diagnostics.Exceptions
{
    public partial class ExceptionHelper
    {
        [DoesNotReturn]
        internal static void CaptureNoReturn(ExceptionType exception, string? category, string? message, WhileExceptionOccur exceptionOccur)
        {
            ExceptionSystem.Capture(exception, exceptionOccur);
            Log.Print(ExceptionSystem.NewException(exception, category, message).Message);
        }
    }
}
