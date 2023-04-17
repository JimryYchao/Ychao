using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ychao.Diagnostics.Exceptions
{
    public delegate void WhileExceptionOccur();

    internal sealed class ExceptionSystem
    {
        internal static bool AllowWriteToLogFile { get; set; }

        internal static async void Capture(ExceptionType exception, WhileExceptionOccur? whileCapture)
        {
            whileCapture?.Invoke();
            if (AllowWriteToLogFile)
                ExceptionTrace.WriteLine(NewException(exception, null, null).Message, MessageCategory.EXCEPTION, true);

            // handle Exception
            if (ExceptionCode.GetCode(exception) > 0)
            {
                // 异步处理
                //handle
                await new Task(() =>
                {
                    Console.WriteLine("");


                });
            }
        }

        internal static Exception NewException(ExceptionType exception, string? category, string? message)
        {
            var msg = category != null ? $" [{category}] : " : string.Empty + message != null ? message : string.Empty;

            return exception switch
            {
                ExceptionType.InvalidCastException => new InvalidCastException(category),
                //...



                _ => new Exception(category)
            };
        }
    }
}
