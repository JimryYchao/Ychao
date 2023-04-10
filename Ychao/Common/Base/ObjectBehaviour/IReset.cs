namespace Ychao
{
    public interface IReset
    {
        void Reset();
        bool IsReset { get; }
        int version { get; }
    }

    public delegate void OnReset(IReset reset);
    public delegate void OnResetBefore(IReset reset);
    public delegate void OnResetCompleted(IReset reset);
}
