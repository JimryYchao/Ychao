using System;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Ychao.Diagnostics;

namespace Ychao.Diagnostics
{
    /// <summary>
    /// Provides default implementation for assert and Write in CodeDebug class.
    /// </summary>
    internal class CodeTraceProvider : CodeDebugProvider
    {
        public CodeTraceProvider(bool canWriteToFile) : base(canWriteToFile) { }

        protected override void WriteCore(string message, MessageCategory category)
        {
            switch (category)
            {
                case MessageCategory.DEBUG:
                    break;
                case MessageCategory.INFO:
                    break;
                case MessageCategory.WARNING:
                    break;
                case MessageCategory.ERROR:
                    break;
                case MessageCategory.EXCEPTION:
                    break;
                default:
                    break;
            }
            Trace.WriteLine(message);
            if (!AutoFlush)
                AutoFlush = true;
        }
    }
}
