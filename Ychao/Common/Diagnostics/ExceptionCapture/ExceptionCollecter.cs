using System;

namespace Ychao.Diagnostics.Exceptions
{
    public partial class ExceptionCollecter
    {
        public delegate void WhileExceptionCaptured();


        public static void Capture(System.Exception ex)
        {
            // Exception Handle
        }

        public static void Capture(Exception ex, WhileExceptionCaptured action)
        {
            // Exception Handle


            action?.Invoke();
        }

        public static void Capture(int errCode)
        {
            // Exception Handle
        }

        public static void Capture(int errCode, WhileExceptionCaptured action)
        {
            // Exception Handle


            action?.Invoke();
        }

    }
}
