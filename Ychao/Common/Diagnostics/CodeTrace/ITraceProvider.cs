using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao.Common.Diagnostics.CodeTrace
{
    public interface ITraceProvider
    {
        void WriteLine(string message, int indentLevel = 0);

        void Fail(string message);

        int FlashFrequency
        {
            get;
            set;
        }
    }
}
