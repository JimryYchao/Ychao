using System;

namespace Ychao.Unity
{
    public partial class ThrowHelper : Ychao.ThrowHelper
    {
        //public static Exception Throw(string paramName)
        //{

        //}

        //public static Exception Throw(string ) { }



        static Exception GetArgumentName(UnityExceptionArgument argument)
        {
            return argument switch
            {


                _ => default!
            };
        }

        static string GetResourceName(UnityExceptionResource resource)
        {
            return resource switch
            {

                _ => default!
            };
        }

    }
}
