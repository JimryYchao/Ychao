using UnityEngine;

namespace Ychao.Unity
{
    public sealed class MonoCollecter //: ISingleton<MonoCollecter>
    {
        public int UID => throw new System.NotImplementedException();
        public bool IsGlobalSingle => throw new System.NotImplementedException();

        private MonoCollecter()
        {
            System.Console.WriteLine(222222);
        }

        public void T()
        {
            System.Console.WriteLine(1111);

        }
    }
}
