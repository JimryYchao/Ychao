using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Ychao.Diagnostics
{
    internal sealed class DebugOutput
    {
#if NETSTANDARD
        static string DefaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Log/";
#elif NET6_0_OR_GREATER
        static string DefaultFilePath = Environment.ProcessPath + "/Log/";
#endif 

        public static void LogMassage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            if (!Directory.Exists(DefaultFilePath))
                Directory.CreateDirectory(DefaultFilePath);

            Console.WriteLine(DefaultFilePath);

            using (FileStream fs = new FileStream(DefaultFilePath + "Log.txt", FileMode.Append))
            {
                fs.Write(new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(message)));
            }
        }

        public void OutPut(string path, string filename)
        {
            // Create a new stream object for an output file named TestFile.txt.
            if(!Directory.Exists(path))
            using (FileStream myFileStream =
                new FileStream("TestFile.txt", FileMode.Append))
            {
                // Add the stream object to the trace listeners.
                TextWriterTraceListener myTextListener =
                    new TextWriterTraceListener(myFileStream);
                Trace.Listeners.Add(myTextListener);

                // Write output to the file.
                Debug.WriteLine("Test output");

                // Flush and close the output stream.
                Debug.Flush();
                Debug.Close();
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

        public bool CanOutputTxt => true;

    }
}
