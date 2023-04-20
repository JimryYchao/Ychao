using System;
using System.Collections.Generic;
using System.Text;
using Ychao.UID;

namespace Ychao.Extension
{
    public static class SingletonExtension
    {
        public static T Singleton<T>(this T instance) where T : class, ISingleton<T>
        {
            if (instance == null)
                instance = ISingleton<T>.Singleton;
            return instance;
        }

        public static void ReflectionCtorCheck<T>(this T instance) where T : class, ISingleton<T>
        {
            if (instance != null)
                ThrowHelper.Exception("Reflection is forbidden because a unique singleton already exists.");
        }
    }
}
