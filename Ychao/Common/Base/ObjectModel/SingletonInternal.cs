using System;
using System.Collections.Generic;
using System.Text;
using Ychao.UID;

namespace Ychao
{
    internal abstract class SingletonInternal<T> : ISingleton<T> where T : class, ISingleton<T>
    {
        protected SingletonInternal()
        {
            
        }

        public long UID => UIDHelper.GetGlobalUID(this);

        public static T Singleton => ISingleton<T>.Singleton;

    }
}
