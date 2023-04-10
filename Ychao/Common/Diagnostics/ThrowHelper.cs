using System;
using Ychao.Diagnostics;
using Ychao.Diagnostics.Exceptions;

namespace Ychao
{
    public partial class ThrowHelper
    {
        public static void Null() => throw null;

        public static Exception InvalidOperationException(string message)
            => new InvalidOperationException(message);
        public static Exception InvalidOperationException(ExceptionInvalidOperationResource resource)
            => new InvalidOperationException(ExceptionHelper.GetInvalidOperationResource(resource));
        public static Exception InvalidOperationException()
            => new InvalidOperationException();

        public static Exception NotImplementedException(string message)
            => new NotImplementedException(message);
        public static Exception NotImplementedException()
            => new NotImplementedException();

        internal static Exception ArgumentException(ExceptionArgumentResource source)
            => new ArgumentException(ExceptionHelper.GetArgumentResourceName(source));

        public static Exception ArgumentOutOfRangeException(string paramName)
            => new ArgumentOutOfRangeException(paramName);
        public static Exception ArgumentOutOfRangeException(string paramName, ExceptionArgumentResource resource)
            => new ArgumentOutOfRangeException(paramName, ExceptionHelper.GetArgumentResourceName(resource));
        public static Exception ArgumentOutOfRangeException()
            => new ArgumentOutOfRangeException();
        public static Exception ArgumentOutOfRangeException(ExceptionArgument argument, string message)
            => new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentName(argument), message);
        public static Exception ArgumentOutOfRangeException(ExceptionArgument argument)
            => new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentName(argument));

        public static Exception ArgumentNullException(string paramName)
            => new ArgumentNullException(paramName);
        public static Exception ArgumentNullException(ExceptionArgument argument)
            => ArgumentNullException(ExceptionHelper.GetArgumentName(argument));






      


    }
}
