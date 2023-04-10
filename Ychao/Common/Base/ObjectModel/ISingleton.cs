using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks.Sources;

namespace Ychao
{
    public interface ISingleton<T> where T : class, ISingleton<T>
    {
        long UID { get; }

        static T GetSingleton()
        {
            if (m_singleton == null)
            {
                var ctors = typeof(T).GetConstructors(BindingFlags.Instance
                 | BindingFlags.NonPublic);

                if (ctors.Count() != 1)
                    throw ThrowHelper.InvalidOperationException(String.Format("Type {0} must have exactly one constructor.", typeof(T)));

                var ctor = ctors.SingleOrDefault(c => !c.GetParameters().Any() && (c.IsPrivate || c.IsFamily));
                if (ctor == null)
                    throw ThrowHelper.InvalidOperationException(String.Format("The constructor for {0} must be private or protected and take no parameters.", typeof(T)));
                m_singleton = (T)ctor.Invoke(null);
            }
            return m_singleton;
        }

        internal static void ReBindSingleton(T instance)
        {
            if (instance == null)
                throw ThrowHelper.ArgumentNullException(nameof(T));

            ISingleton<T> _pre;

            lock (m_singleton)
            {
                _pre = m_singleton;
                m_singleton = instance;
            }
            // IDestroy ... IDispose ... 
            if (_pre is IDispose)
                Core.Dispose(_pre);

            if (_pre is IDestroy)
                Core.Destroy(_pre);


        }

        private static T m_singleton;

        public static T Singleton
        {
            get => GetSingleton();
        }
    }
}
