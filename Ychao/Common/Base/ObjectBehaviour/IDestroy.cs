namespace Ychao
{
    public interface IDestroy
    {
        void OnDestroy();
    }

    public delegate void OnDestroy(IDestroy destroy);
    public delegate void OnDestroyBefore(IDestroy destroy);
    public delegate void OnDestroyCompleted(IDestroy destroy);
}
