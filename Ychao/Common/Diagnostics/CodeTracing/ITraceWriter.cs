using System.IO;

namespace Ychao.Diagnostics
{
    internal interface ITraceWriter
    {
        StreamWriter StreamWriter { get; }


    }
}
