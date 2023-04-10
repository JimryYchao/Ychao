namespace Ychao
{
    public interface IStart
    {
        void OnStart();
    }

    public delegate void OnStart(IStart start);
    public delegate void OnStartBefore(IStart start);
    public delegate void OnStartCompleted(IStart start);
}
