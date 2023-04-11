using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ychao.Diagnostics
{
    internal interface ITextWriter
    {
        StreamWriter StreamWriter { get; }


    }
}
