using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Ychao
{
    public enum ExceptionType
    {
        Unknown = -1,
        Exception,

        //
        ArgumentException = 1000,
        ArgumentNullException = 1001,
        ArgumentOutOfRangeException = 1002,

        NullReferenceException = 5001,
        IndexOutOfRangeException = 5002,
        NotImplementedException,
        InvalidCastException,

        InvalidOperationException,
        NotSupportedException,
    }

    namespace Diagnostics.Exceptions
    {

        internal partial class ExceptionCode
        {
            internal static int GetCode(ExceptionType exception)
            {
                return (int)exception;
            }
        }

        internal partial class ExceptionResource
        {
            internal static string GetResource(ExceptionType exception)
            {
                return exception switch
                {





                    _ => string.Empty,
                };
            }
        }
    }
}

