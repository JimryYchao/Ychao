using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao
{
    public static class GlobalSetting
    {
        public static LogMode GlobalLogMode { get => LogSystem.GlobalMode; set => LogSystem.GlobalMode = value; }
        public static bool AllowOutput { get; set; }





    }
}
