using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Linq;

namespace Ychao.Logs.Utils
{
    internal class ConsoleHelper
    {
        static Process ConsoleCMD;
        static Thread ConsoleThread;
        static bool IsCmdStarted;

        static event Action OutputConsole;

        /// <summary>
        /// 待完善
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="message"></param>
        public static void LogToConsole(LogMode mode, object message)
        {
            if (!IsCmdStarted)
            {
                ConsoleThread = new Thread(() =>
                {
                    IsCmdStarted = true;
                    ConsoleCMD = new Process();

                    ConsoleCMD.StartInfo.FileName = "systeminfo.exe";
                    ConsoleCMD.StartInfo.UseShellExecute = false;
                    ConsoleCMD.StartInfo.RedirectStandardInput = false;
                    ConsoleCMD.StartInfo.RedirectStandardOutput = true;
                    ConsoleCMD.StartInfo.RedirectStandardError = true;

                    ConsoleCMD.StartInfo.CreateNoWindow = false;
                    ConsoleCMD.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                    ConsoleCMD.Start();

                    while (IsCmdStarted)
                    {
                        if (OutputConsole != null)
                        {
                            OutputConsole.Invoke();
                            OutputConsole = null;
                        }
                    }

                    ConsoleCMD.WaitForExit();
                    ConsoleCMD.Dispose();
                    ConsoleCMD.Close();
                    IsCmdStarted = false;
                });

                ConsoleThread.Start();

            }


            if ((mode & LogMode.Info & LogMode.Debug & LogMode.Warning) > 0)
                ConsoleCMD.OutputDataReceived += (o, _e) => Console.WriteLine(message);
            else if ((mode & LogMode.Exception & LogMode.Fatal & LogMode.Error) > 0)
                ConsoleCMD.ErrorDataReceived += (o, _e) => Console.WriteLine(message);
        }
    }
}
