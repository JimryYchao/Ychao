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
            try
            {
                //Log.Exception(ex, ex.Message);
            }
            catch
            {
                throw ex;// new Exception(/*StackTraceHelper.GetCallStacksInfo(1, true)*/ "  q", ex);
            }
        }
        [DoesNotReturn]
        public static void Exception(string message)
        {
            Exception(ExceptionType.Exception, null, message);
            Console.WriteLine("do not return ");
        }

        [DoesNotReturn]
        public static void Null() => throw null;
    }
}
