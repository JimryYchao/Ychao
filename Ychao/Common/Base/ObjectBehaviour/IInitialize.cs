namespace Ychao
{
    public interface IInitialize
    {
        void Initialize();

        bool IsInited { get; }
    }

    public delegate void OnInitialize(IInitialize obj);
    public delegate void OnInitialize<T>(IInitialize obj, T t);
    public delegate void OnInitialize<T, T1>(IInitialize obj, T t, T1 t1);
    public delegate void OnInitialize<T, T1, T2>(IInitialize obj, T t, T1 t1, T2 t2);
    public delegate void OnInitialize<T, T1, T2, T3>(IInitialize obj, T t, T1 t1, T2 t2, T3 t3);

    public delegate void OnInitializeBefore(IInitialize obj);
    public delegate void OnInitializeCompleted(IInitialize obj);
}
