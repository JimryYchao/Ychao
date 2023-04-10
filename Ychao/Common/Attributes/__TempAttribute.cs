using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ychao
{
    /// <summary>
    /// Temp Operation. Not Implemented Or Replaced !!! 
    /// </summary>
    [__Temp] 
    public sealed class __TempAttribute : Attribute
    {
        public string explain { get; private set; }

        public __TempAttribute() => explain = "Temp Operation";

        public __TempAttribute(string explain) => explain = "Temp >> " + explain;

    }
}
