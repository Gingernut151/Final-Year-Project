using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

using SharedLibrary;

namespace ClientLibrary
{
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public abstract class ClientConnection
    {
        protected string _connectionName;
        public ISerializer _serializer;
        protected List<Packet> _packetList;
        protected Thread _thread;
        protected string _username;

        public abstract void Start();
        public abstract void Stop();
        public abstract void AddSerializer(ISerializer serializer);
        public abstract string GetConnectionName();
        public abstract void Send(Packet data);
        public abstract List<Packet> CollectDataPackets();
        public abstract void ClearDataPackets();
        public abstract void ChangeUsername(String username);
    }
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public class ClientConnectionTCP : ClientConnection
    {
        private ClientListenerTCP _listener;

        private NetworkStream _stream;
        private BinaryWriter _writer;
        private BinaryReader _reader;
        //-----------------------------------------------------------------------------------------
        public ClientConnectionTCP(string connectionName, string username)
        {
            _username = username;
            _connectionName = connectionName;
            _packetList = new List<Packet>();
        }
        //-----------------------------------------------------------------------------------------
        public override void Start()
        {
            _listener.Start();

            _stream = _listener.GetStream();
            _writer = new BinaryWriter(_stream, Encoding.UTF8);
            _reader = new BinaryReader(_stream, Encoding.UTF8);

            _thread = new Thread(new ThreadStart(this.ProcessServerResponse));
            _thread.Start();
        }
        //-----------------------------------------------------------------------------------------
        public override string GetConnectionName()
        {
            return _connectionName;
        }
        //-----------------------------------------------------------------------------------------
        public override void Stop()
        {
            DisconnectPacket packet = new DisconnectPacket(_username, 0);
            Send(packet);

            Thread.Sleep(50);
            Disconnect();
        }
        //-----------------------------------------------------------------------------------------
        private void Disconnect()
        {
            _listener.Stop();
            _thread.Abort();
        }
        //-----------------------------------------------------------------------------------------
        public override void AddSerializer(ISerializer serializer)
        {
            _serializer = serializer;
        }
        //-----------------------------------------------------------------------------------------
        public void AddListener(ClientListenerTCP listener)
        {
            _listener = listener;
        }
        //-----------------------------------------------------------------------------------------
        public override void Send(Packet data)
        {
            byte[] buffer = _serializer.Serialize(data);

            try
            {
                _writer.Write(buffer.Length);
                _writer.Write(buffer);
                _writer.Flush();
            }

            catch (ObjectDisposedException e)
            {

            }
        }
        //-----------------------------------------------------------------------------------------
        private void ProcessServerResponse()
        {
            try
            {
                _reader = new BinaryReader(_stream, Encoding.UTF8);
            }

            catch (ArgumentException e)
            {

            }

            int noOfIncomingBytes;
            try
            {
                while ((noOfIncomingBytes = _reader.ReadInt32()) != 0)
                {
                    byte[] bytes = _reader.ReadBytes(noOfIncomingBytes);
                    Packet packet = _serializer.Deserialize(bytes);

                    CheckForPacketDisconnect(packet);
                    _packetList.Add(packet);
                }
            }
            catch (IOException e)
            {

            }

            catch (ObjectDisposedException e)
            {

            }
        }
        //-----------------------------------------------------------------------------------------
        public override List<Packet> CollectDataPackets()
        {
            return _packetList;
        }
        //-----------------------------------------------------------------------------------------
        public override void ClearDataPackets()
        {
            _packetList.Clear();
        }
        //-----------------------------------------------------------------------------------------
        private void CheckForPacketDisconnect(Packet packet)
        {
            if (packet.type == PacketType.DISCONNECT)
            {
                Disconnect();
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void ChangeUsername(String username)
        {
            _username = username;
        }
    }


    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public class ClientConnectionUDP : ClientConnection
    {

        private ClientListenerUDP _listener;
        //-----------------------------------------------------------------------------------------
        public ClientConnectionUDP(string connectionName, string username)
        {
            _username = username;
            _connectionName = connectionName;
            _packetList = new List<Packet>();
        }
        //-----------------------------------------------------------------------------------------
        public override void Start()
        {
            _listener.Start();

            _thread = new Thread(new ThreadStart(this.ProcessServerResponse));
            _thread.Start();
        }
        //-----------------------------------------------------------------------------------------
        public override void Stop()
        {
            DisconnectPacket packet = new DisconnectPacket(_username, 0);
            Send(packet);
            Thread.Sleep(50);
            Disconnect();
        }
        //-----------------------------------------------------------------------------------------
        private void Disconnect()
        {
            _listener.Stop();
            _thread.Abort();
        }
        //-----------------------------------------------------------------------------------------
        public override void AddSerializer(ISerializer serializer)
        {
            _serializer = serializer;
        }
        //-----------------------------------------------------------------------------------------
        public void AddListener(ClientListenerUDP listener)
        {
            _listener = listener;
        }
        //-----------------------------------------------------------------------------------------
        public override string GetConnectionName()
        {
            return _connectionName;
        }
        //-----------------------------------------------------------------------------------------
        public override void Send(Packet data)
        {
            byte[] buffer = _serializer.Serialize(data);

            _listener.SendUdpPacket(buffer);
        }
        //-----------------------------------------------------------------------------------------
        private void ProcessServerResponse()
        {
            while (true)
            {
                byte[] bytes = _listener.ReceiveUdpPackets();

                if (bytes != null)
                {
                    Packet packet = _serializer.Deserialize(bytes);

                    _packetList.Add(packet);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public override List<Packet> CollectDataPackets()
        {
            return _packetList;
        }
        //-----------------------------------------------------------------------------------------
        public override void ClearDataPackets()
        {
            _packetList.Clear();
        }
        //-----------------------------------------------------------------------------------------
        public override void ChangeUsername(String username)
        {
            _username = username;
        }
    }
}
