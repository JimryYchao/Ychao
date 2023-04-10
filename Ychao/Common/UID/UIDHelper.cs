using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Ychao.UID
{
    public partial class UIDHelper
    {
        // 限制 Core Global UID 在 -(1<<10 ~ (1<<11)-1)
        // 
        static Dictionary<string, long> GlobalUIDs = new Dictionary<string, long>();

        internal static long GetGlobalUID(object obj)
        {
            if (GlobalUIDs.ContainsKey(obj.GetType().Name))
                return GlobalUIDs[obj.GetType().Name];

            unchecked
            {
                long code = obj.GetHashCode().Abs() + 1 << 10;
                while (GlobalUIDs.ContainsValue(code))
                    code = (code / 2 + int.MaxValue) + 1 << 10;

                GlobalUIDs.Add(obj.GetType().Name, code);
                return code;
            }
        }

        public static long GetUID(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
