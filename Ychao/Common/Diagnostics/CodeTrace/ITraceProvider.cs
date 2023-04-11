using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao.Diagnostics
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
