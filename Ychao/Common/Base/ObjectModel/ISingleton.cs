using System;
using System.Linq;
using System.Reflection;

namespace Ychao
{
    public interface ISingleton<T> where T : class, ISingleton<T>
    {
        long UID { get; }

        bool CanBeDestroyed { get; }

        static T GetSingleton()
        {
            if (m_singleton == null)
            {
                var ctors = typeof(T).GetConstructors(BindingFlags.Instance
                 | BindingFlags.NonPublic);

                if (ctors.Count() != 1)
                    throw ThrowHelper.InvalidOperation(String.Format("Type {0} must have exactly one constructor.", typeof(T)));

                var ctor = ctors.SingleOrDefault(c => !c.GetParameters().Any() && (c.IsPrivate || c.IsFamily));
                if (ctor == null)
                    throw ThrowHelper.InvalidOperation(String.Format("The constructor for {0} must be private or protected and take no parameters.", typeof(T)));
                m_singleton = (T)ctor.Invoke(null);
            }
            return m_singleton;
        }

        private static T m_singleton;

        public static T Singleton
        {
            get => GetSingleton();
        }
    }
}
