using System;
using Ychao.Diagnostics;
using Ychao.Diagnostics.Exceptions;

namespace Ychao
{
    public partial class ThrowHelper
    {
        public static void Null() => throw null;

        public static Exception InvalidOperation(string message) => new InvalidOperationException(message);
        public static Exception InvalidOperation(ExceptionInvalidOperationResource resource) => new InvalidOperationException(GetInvalidOperationResource(resource));
        public static Exception InvalidOperation() => new InvalidOperationException();
        
        public static Exception NotImplemented(string message) => new NotImplementedException(message);
        public static Exception NotImplemented() => new NotImplementedException();


        public static Exception ArgumentOutOfRange(string paramName)=> new ArgumentOutOfRangeException(paramName);
        public static Exception ArgumentOutOfRange(string paramName, ExceptionArgumentResource resource) => new ArgumentOutOfRangeException(paramName, ExceptionHelper.GetArgumentResourceName(resource));
        public static Exception ArgumentOutOfRange() => new ArgumentOutOfRangeException();
        public static Exception ArgumentOutOfRange(ExceptionArgument argument, string message) => new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentName(argument), message);
        public static Exception ArgumentOutOfRange(ExceptionArgument argument) => new ArgumentOutOfRangeException(GetArgumentName(argument));
        {
            throw 
        }
        internal static Exception ArgumentNull(string paramName)
        {
            throw new ArgumentNullException(paramName);
        }
        public static Exception ArgumentNull(ExceptionArgument argument)
        {
            return ArgumentNull(ExceptionHelper.GetArgumentName(argument));
        }

        internal static Exception Argument(ExceptionArgumentResource source)
        {
            return new ArgumentException(GetArgumentResourceName(source));
        }


      

        static string GetInvalidOperationResource(ExceptionInvalidOperationResource resource)
        {
            return resource switch
            {
                ExceptionInvalidOperationResource.Cannot_Remove_From_Stack_Or_Queue => "InvalidOperation_CannotRemoveFromStackOrQueue",
                ExceptionInvalidOperationResource.Empty_Queue => "InvalidOperation_EmptyQueue",
                ExceptionInvalidOperationResource.Enum_Op_CantHappen => "InvalidOperation_EnumOpCantHappen",
                ExceptionInvalidOperationResource.Enum_Failed_Version => "InvalidOperation_EnumFailedVersion",
                ExceptionInvalidOperationResource.Empty_Stack => "InvalidOperation_EmptyStack",
                ExceptionInvalidOperationResource.Enum_Not_Started => "InvalidOperation_EnumNotStarted",
                ExceptionInvalidOperationResource.Enum_Ended => "InvalidOperation_EnumEnded",
                ExceptionInvalidOperationResource.No_Value => "InvalidOperation_NoValue",
                ExceptionInvalidOperationResource.Reg_Remove_Sub_Key => "InvalidOperation_RegRemoveSubKey",
                _ => default!
            };
        }


    }
}
