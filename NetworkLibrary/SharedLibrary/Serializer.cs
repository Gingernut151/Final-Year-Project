using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ProtoBuf;

namespace SharedLibrary
{
    public interface ISerializer
    {
        byte[] Serialize(Packet packet);
        Packet Deserialize(byte[] streamData);
    }
    //-----------------------------------------------------------------------------------------
    public class DotNetserialization : ISerializer
    {
        public byte[] Serialize(Packet packet)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, packet);

            return stream.GetBuffer();
        }
        //-----------------------------------------------------------------------------------------
        public Packet Deserialize(byte[] streamData)
        {
            MemoryStream memoryStream = new MemoryStream(streamData);
            BinaryFormatter formatter = new BinaryFormatter();

            Packet packet = formatter.Deserialize(memoryStream) as Packet;

            return packet;
        }
    }
    //-----------------------------------------------------------------------------------------
    public class ProtoBufSerializer : ISerializer
    {
        public byte[] Serialize(Packet packet)
        {
            MemoryStream stream = new MemoryStream();
            Serializer.Serialize<Packet>(stream, packet);

            return stream.ToArray();
        }
        //-----------------------------------------------------------------------------------------
        public Packet Deserialize(byte[] streamData)
        {
            MemoryStream memoryStream = new MemoryStream(streamData);
            Packet packet = Serializer.Deserialize<Packet>(memoryStream);

            return packet;
        }
    }
}
