using Ychao.Serialization;

namespace Ychao.Network.Tcp
{
    public sealed class TcpConnecter
    {
        public static void SetDataSerializer(ISerializer serializer)
        {
            BinarySerializer.serializer = serializer;
        }


    }
}
