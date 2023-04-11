using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Ychao.Diagnostics
{
    internal class CodeDebugProvider : IDebugProvider
    {
        private int ThreadID = -1;

        


        public CodeDebugProvider(int ThreadID)
        {
            this.ThreadID = ThreadID;
        }

        #region DEBUG
        void __WriteLine(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            Debug.WriteLine(message);
        }

        public void WriteLine(string message)
        {
            __WriteLine((message[0] != '#' ? "|| " : "|") + message);
        }

        public void Fail(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                WriteLine("# ---------------- ASSERT FAILED ----------------");
                WriteLine(message);
            }
        }

        public void PrintStackTraceDetail(int frame, bool outputThreadId = false)
        {
            string stack;
            try
            {
                stack = new StackTrace(frame).ToString();
            }
            catch
            {
                stack = string.Empty;
            }

            if (!string.IsNullOrEmpty(stack))
            {
                using (StringReader sr = new StringReader(stack))
                {
                    string line = string.Empty;
                    while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                        __WriteLine("|| \t\t" + line);
                }
                if (outputThreadId)
                    __WriteLine("|| \t\t\t" + "At Thread >>>> " + ThreadID);
            }
        }
        #endregion


        #region OUTPUT
        public bool CanOutputTxt { get; set; }

        class TextWriter : Ychao.Diagnostics.TextWriter
        {
            public static 




        }






        #endregion
    }
}
