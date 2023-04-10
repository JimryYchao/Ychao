namespace Ychao
{
    public interface IFixedUpdate
    {
        void OnFixedUpdate();
    }

    public delegate void OnFixedUpdate(IFixedUpdate fixedUpdate);
    public delegate void OnFixedUpdateBefore(IFixedUpdate fixedUpdate);
    public delegate void OnFixedUpdateCompleted(IFixedUpdate fixedUpdate);
}
