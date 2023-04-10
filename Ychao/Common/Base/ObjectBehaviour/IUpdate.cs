namespace Ychao
{
    public interface IUpdate
    {
        void OnUpdate();
    }

    public delegate void OnUpdatep(IUpdate update);
    public delegate void OnUpdateBefore(IUpdate update);
    public delegate void OnUpdateCompleted(IUpdate update);
}
