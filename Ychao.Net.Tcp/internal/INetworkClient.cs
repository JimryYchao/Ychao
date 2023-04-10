namespace Ychao.Network
{
    public interface INetworkClient
    {
        bool IsInterrupted { get; init; }

        void SendData(byte[] stream);

        byte[] ReceiveData();
    }
}
