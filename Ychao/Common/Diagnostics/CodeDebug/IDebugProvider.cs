using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao.Diagnostics
{
    public interface IDebugProvider
    {
        void WriteLine(string message, int indentLevel = 0);
        void Fail(string message, string detail);

        int FlashFrequency
        {
            get;
            set;
        }
    }
}
