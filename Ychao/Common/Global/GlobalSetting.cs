using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao
{
    public static class GlobalSetting
    {
        public static LogMode GlobalLogMode { get => LogManager.GlobalMode; set => LogManager.GlobalMode = value; }
        public static bool AllowLogToCmd { get; set; }





    }
}
