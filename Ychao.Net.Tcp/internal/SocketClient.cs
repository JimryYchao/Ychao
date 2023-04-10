using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace Ychao.Network
{
    public abstract class SocketClient : INetworkClient, IDisposable
    {
        protected internal Socket socket { get; }

        public abstract bool IsInterrupted { get; init; }

        public abstract byte[] ReceiveData();

        public abstract void SendData(byte[] stream);

        public SocketClient(Socket socket)
        {
            if (socket == null || !socket.Connected)
                throw new ArgumentNullException(socket.ToString());
            this.socket = socket;
        }

        public void Close()
        {
            socket.Close();
        }

        public void Dispose()
        {
            socket.Dispose();

        }
    }
}
