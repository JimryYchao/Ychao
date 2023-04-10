using System;
using Ychao.Serialization;

namespace Ychao.Network
{
    [Serializable]
    internal sealed class BinarySerializer
    {
        internal static ISerializer serializer = SerializerTaker.NormalizedSerializer;

        public static object Deserialize(byte[] data)
        {
            return serializer.Deserialize(data);
        }

        public static byte[] Serialize(object data)
        {
            return serializer.Serialize(data);
        }
    }
}
