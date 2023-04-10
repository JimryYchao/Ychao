using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ychao.UID;

namespace Ychao.Logs
{
    internal class LogCollecter : ISingletonInternal<LogCollecter>
    {
        private LogCollecter()
        {
            this.ReflectionCtorCheck();
            UID = UIDHelper.GetGlobalUID(this);
        }

        public long UID { get; }

        public long Capacity { get; set; }
        public long MaxLogsCount { get; set; }
        public unsafe long BufferSize { get => Marshal.SizeOf(LogCollection); }
        public bool CanBeDestroyed => throw new NotImplementedException();

        Queue<object> LogCollection = new Queue<object>(10);

        public void EnLog(object log)
        {
            LogCollection.Enqueue(log);
            Console.WriteLine(BufferSize);
        }

        public object DeLog()
        {
            return LogCollection.Dequeue();
        }
    }
}
