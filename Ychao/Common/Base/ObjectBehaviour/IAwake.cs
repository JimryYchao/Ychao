using System;

namespace Ychao
{
    public interface IAwake
    {
        void OnAwake();
    }

    public delegate void OnAwake(IAwake awake);
    public delegate void OnAwakeBefore(IAwake awake);
    public delegate void OnAwakeCompleted(IAwake awake);
}
