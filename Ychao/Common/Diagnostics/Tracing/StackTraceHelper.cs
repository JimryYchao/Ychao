using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Ychao.Diagnostics
{
    public sealed class StackTraceHelper
    {
        public static string GetCallStacksInfo(int skipFrames, bool needFileInfo)
        {
            StackTrace st = new StackTrace(skipFrames + 1, needFileInfo);
            string stackIndent = "";

            StringBuilder sb = new StringBuilder("\n");
            for (int i = 0; i < st.FrameCount; i++)
            {
                var frame = st.GetFrame(i);
                if (frame == null)
                    continue;
                MethodBase mb = frame.GetMethod();

                string method = mb.ToString();

                int p = 0;
                while (p < method.Length)
                {
                    if (method[p] == '(')
                    {
                        for (int j = p; j > 0; j--)
                        {
                            if (method[j] == ' ')
                            {
                                method = method.Substring(j + 1);
                                break;
                            }
                        }
                        break;
                    }
                    p++;
                }

                sb.AppendLine(stackIndent + $"  at Method : {mb.DeclaringType.FullName}.{method}");

                if (needFileInfo)
                    sb.AppendLine(stackIndent + $"  in File : {frame.GetFileName()} at Line({frame.GetFileLineNumber()}:{frame.GetFileColumnNumber()})");
                stackIndent += "    ";
            }
            return sb.ToString();
        }

        public static StackTrace GetCallStacks(int skipFrames, bool needFileInfo)
        {
            return new StackTrace(skipFrames + 1, needFileInfo);
        }

        public static string GetCallStackInfo(bool needFileInfo)
        {
            StackFrame frame = new StackFrame(1, needFileInfo);

            StringBuilder sb = new StringBuilder("\n");

            MethodBase mb = frame.GetMethod();

            string method = mb.ToString();

            int p = 0;
            while (p < method.Length)
            {
                if (method[p] == '(')
                {
                    for (int j = p; j > 0; j--)
                    {
                        if (method[j] == ' ')
                        {
                            method = method.Substring(j + 1);
                            break;
                        }
                    }
                    break;
                }
                p++;
            }

            sb.AppendLine($"  Called at Method : {mb.DeclaringType.FullName}.{method}");
            if (needFileInfo)
                sb.AppendLine($"  in File : [{frame.GetFileName()}] at Line({frame.GetFileLineNumber()}:{frame.GetFileColumnNumber()})");

            return sb.ToString();

        }

        public static StackFrame GetCallStack(bool needFileInfo)
        {
            return new StackFrame(1, needFileInfo);
        }
    }
}
