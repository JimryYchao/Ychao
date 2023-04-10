using UnityEngine;

namespace Ychao.Unity
{
    public interface IMonoGlobalSingleton<T> where T : MonoBase
    {
        private static T m_singleton { get; set; }

        static T GetSingleton()
        {
            if (!m_singleton)
            {
                m_singleton = GameObject.FindFirstObjectByType<T>();
                if (!m_singleton)
                    m_singleton = new GameObject(typeof(T).Name).AddComponent<T>();
                GameObject.DontDestroyOnLoad(m_singleton);
            }
            return m_singleton;
        }

        public static void SetSingleton(T instance)
        {
            if (instance == null)
                instance = GetSingleton();
            else
            {
                if(!m_singleton)
                    m_singleton = instance;
                else if(object.ReferenceEquals(m_singleton, instance))
                {
                    GameObject.Destroy(instance);
                    instance = GetSingleton();
                }
            }
            GameObject.DontDestroyOnLoad(m_singleton);
        }

        public static void SetSingleton(T instance, Transform parent, bool worldPositionStays)
        {
            SetSingleton(instance);
            m_singleton.SetParent(parent, worldPositionStays);
        }

        public static T Singleton => GetSingleton();
    }
}
