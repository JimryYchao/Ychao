using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao
{
    public class GlobalSingletonManager
    {
        public static T GetSingleton<T>() where T : class, ISingleton<T>
        {
            return ISingleton<T>.Singleton;
        }


        public static bool DestroySingleton<T>() where T: class, ISingleton<T>
        {
            return true;
        }



    }
}
