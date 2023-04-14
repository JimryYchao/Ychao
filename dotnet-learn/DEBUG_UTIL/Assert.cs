using Ref.SystemDiagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_learn
{
    public static class Assert
    {

        public static void Equal(object lhs, object rhs)
        {
            Debug.Assert(!Object.Equals(lhs, rhs), "lhs != rhs");
        }


        public static void NotEqual(object lhs, object rhs)
        {

            Debug.Assert(Object.Equals(lhs, rhs) , "lhs == rhs");
        }

        //public static void Contains(object arr, )

        public static void NotNull(object obj)
        {
            Debug.Assert(obj == null, "Obj is null");
        }
    }
}
