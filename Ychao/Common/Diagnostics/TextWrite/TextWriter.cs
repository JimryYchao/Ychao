using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Ychao.Diagnostics;

namespace Ychao.Common.Diagnostics.TextWrite
{
    internal class TextWriterCreater
    {
        static Dictionary<ITextWriter, StreamWriter> Writers = new Dictionary<ITextWriter, StreamWriter>();

        internal static void Close(ITextWriter writer)
        {
            try
            {
                writer?.StreamWriter.Close();
            }
            catch { }

            Writers.Remove(writer);
        }

        internal static void GetWriter(ITextWriter writer)
        {
            //if()
        }


#if NETSTANDARD
        static string DefaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Log/";
#elif NET6_0_OR_GREATER
#endif 
        static string DefaultFilePath = Environment.CurrentDirectory + "/Log/";
        public static string OutputFilePath { get; set; }

        static volatile bool OnWrite = false;

        //public static void OutputContent(string message)
        //{
        //    if (string.IsNullOrEmpty(message))
        //        return;

        //    if (!Directory.Exists(DefaultFilePath))
        //        Directory.CreateDirectory(DefaultFilePath);

        //    Console.WriteLine(DefaultFilePath);

        //    using (FileStream fs = new FileStream(DefaultFilePath + "Debug.txt", FileMode.Append))
        //        fs.Write(new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(message)));
        //}

        public static void Output(string message, string path)
        {

        }






        public void OutPut(string path, string filename)
        {
            // Create a new stream object for an output file named TestFile.txt.
            if (!Directory.Exists(path))
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


