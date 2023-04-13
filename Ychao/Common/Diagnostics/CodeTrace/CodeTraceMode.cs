using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Ychao.Diagnostics
{
    [Conditional]
    public enum CodeTraceMode
    {
        Release,
        Debug,
    }
}
