using System;

namespace Ychao.Unity
{
    public sealed class MonoEngineCore : MonoBase, IMonoGlobalSingleton<MonoEngineCore>, IMonoInitialize
    {
        public override int UID => throw new NotImplementedException();

        public bool IsGlobalSingle => true;

        private bool m_IsInited;
        public bool IsInited => m_IsInited;

        public void Initialize()
        {
            //if ()
            //{
            //    DestroyImmediate(this);
            //    ThrowHelper.ArgumentOutOfRange(nameof(Singleton));
            //}

            ////Instance = this;
            //DontDestroyOnLoad(Singleton);





        }
    }
}
