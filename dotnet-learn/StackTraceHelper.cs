using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class StackTraceHelper
{
    public static string AtLine()
    {
        return " At Line:" + new StackTrace(1, true)?.GetFrame(0)?.GetFileLineNumber() ?? "-1";
    }
}
