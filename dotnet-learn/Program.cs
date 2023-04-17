﻿using dotnet_learn.SystemDiagnostics.DebugTest;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace dotnet_learn
{
    internal class Program
    {
        [DisallowNull]
        string str = null;

        static void Main(string[] args)
        {
            DebugTests dt = new DebugTests();
            System.Console.WriteLine(dt.Get(" ") ?? "Null");

            pub.Test();
        }

        [DisallowNull]
        static int a;

    }


    public class pub
    {

        public static void Test()
        {
            System.Console.WriteLine(StackTraceHelper.GetCallStacksInfo(0, true));

            System.Console.WriteLine(StackTraceHelper.GetCallStacks(0, true));

            System.Console.WriteLine(StackTraceHelper.GetCallStack(true));

            System.Console.WriteLine(StackTraceHelper.GetCallStackInfo(false));
        }
    }
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
                    sb.AppendLine(stackIndent + $"  in File : [{frame.GetFileName()}] at Line({frame.GetFileLineNumber()}:{frame.GetFileColumnNumber()})");
                stackIndent += "  ";
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
                sb.AppendLine($"  at File : [{frame.GetFileName()}] at Line({frame.GetFileLineNumber()}:{frame.GetFileColumnNumber()})");

            return sb.ToString();

        }
        public static StackFrame GetCallStack(bool needFileInfo)
        {
            return new StackFrame(1, needFileInfo);
        }
    }
}