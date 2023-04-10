namespace Ychao.Unity
{
    public interface IMonoFixedUpdate : IMonoBinds
    {
        void OnFixedUpdate();
    }

    public delegate void OnFixedUpdate(IMonoFixedUpdate fixedUpdate);
    public delegate void OnFixedUpdateBefore(IMonoFixedUpdate fixedUpdate);
    public delegate void OnFixedUpdateCompleted(IMonoFixedUpdate fixedUpdate);
}
