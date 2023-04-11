using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Ychao.Diagnostics
{
    public interface IDebugProvider
    {
        void WriteLine(string message);
        void Fail(string message);
        bool CanOutputTxt { get; }
        void PrintStackTraceDetail(int frame, bool outputThreadId = false);
    }
}
