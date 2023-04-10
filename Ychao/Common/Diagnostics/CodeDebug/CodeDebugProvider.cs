using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Ychao.Diagnostics
{
    internal class CodeDebugProvider : IDebugProvider
    {
        public CodeDebugProvider()
        {
            FlashFrequency = 10;
        }

        public void WriteLine(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;
            Debug.WriteLine(message);
            if (FlashFrequency < 2)
                Debug.Flush();
            else
            {
                Interlocked.Exchange(ref s_counter, s_counter++);
                if (s_counter >= FlashFrequency)
                {
                    Debug.Flush();
                    Interlocked.Exchange(ref s_counter, 0);
                }
            }
        }

        public void Fail(string message, string detail)
        {
            if (!string.IsNullOrEmpty(message))
            {
                WriteLine(message);
            }

            if (!string.IsNullOrEmpty(detail))
            {
                WriteLine("——————    FAIL DETAIL    ——————");
                Debug.Indent();
                WriteLine(detail);
                Debug.Unindent();
            }
        }

        private volatile int s_counter = 0;

        /// <summary>
        /// 小于 2 表示每次写入都将调用一次 Debug.Flush(), 默认值为 10
        /// </summary>
        public int FlashFrequency
        {
            get;
            set;
        }
    }
}
