namespace Ychao
{
    public interface IDispose : System.IDisposable
    {

    }

    public delegate void OnDispose(IDispose obj);

    public delegate void OnDisposeCompleted(IDispose obj);
}
