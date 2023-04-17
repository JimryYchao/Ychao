using System;
using System.Diagnostics.CodeAnalysis;
using Ychao.Diagnostics;
using Ychao.Diagnostics.Exceptions;

namespace Ychao
{
    public partial class ThrowHelper
    {
        [DoesNotReturn]
        public static void Exception(ExceptionType exception, string? category = "", string? message = "", WhileExceptionOccur? whileException = null)
        {
            var ex = ExceptionSystem.NewException(exception, category, message);
            ExceptionSystem.Capture(exception, whileException);
            Log.Exception(ex, ex.Message);
            throw ex;
        }

        [DoesNotReturn]
        public static void Null() => throw null;
    }
}
