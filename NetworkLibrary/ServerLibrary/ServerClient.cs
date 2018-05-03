using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

using SharedLibrary;

namespace ServerLibrary
{
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public abstract class ServerClient
    {
        public String _name;
        public string _address;
        public ISerializer _serializer;

        public abstract void AddSerializer(ISerializer serializer);
        public abstract void Start();
        public abstract void Stop();
        public abstract void Send(Packet packet);
    }
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public class TCPClient : ServerClient
    {
        public ServerListenerTCP _listener;
        public Socket _socket { get; private set; }
        public BinaryReader _reader { get; private set; }
        public BinaryWriter _writer { get; private set; }
        public NetworkStream _stream { get; private set; }
        //-----------------------------------------------------------------------------------------
        public TCPClient(Socket socket, string name)
        {
            _socket = socket;
            _name = name;
            _address = socket.LocalEndPoint.ToString();

            _stream = new NetworkStream(_socket, true);
            _reader = new BinaryReader(_stream, Encoding.UTF8);
            _writer = new BinaryWriter(_stream, Encoding.UTF8);
        }
        //-----------------------------------------------------------------------------------------
        public override void AddSerializer(ISerializer serializer)
        {
            _serializer = serializer;
        }
        //-----------------------------------------------------------------------------------------
        public void AddListener(ServerListenerTCP listener)
        {
            _listener = listener;
        }
        //-----------------------------------------------------------------------------------------
        public override void Start()
        {

        }
        //-----------------------------------------------------------------------------------------
        public override void Stop()
        {
            _socket.Close();
        }
        //-----------------------------------------------------------------------------------------
        public override void Send(Packet packet)
        {
            byte[] buffer = _serializer.Serialize(packet);

            _writer.Write(buffer.Length);
            _writer.Write(buffer);
            _writer.Flush();
        }
        //-----------------------------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public class UDPClient : ServerClient
    {
        public ServerListenerUDP _listener;
        public IPEndPoint _remoteClient;
        //-----------------------------------------------------------------------------------------
        public UDPClient(string name)
        {
            _name = name;
        }
        //-----------------------------------------------------------------------------------------
        public override void AddSerializer(ISerializer serializer)
        {
            _serializer = serializer;
        }
        //-----------------------------------------------------------------------------------------
        public void AddListener(ServerListenerUDP listener)
        {
            _listener = listener;
        }
        //-----------------------------------------------------------------------------------------
        public void AddEndPoint(IPEndPoint endPoint)
        {
            _remoteClient = endPoint;
        }
        //-----------------------------------------------------------------------------------------
        public override void Start()
        {

        }
        //-----------------------------------------------------------------------------------------
        public override void Stop()
        {
            
        }
        //-----------------------------------------------------------------------------------------
        public override void Send(Packet packet)
        {
            byte[] buffer = _serializer.Serialize(packet);

            _listener.SendUdpPacket(buffer, _remoteClient);
        }
        //-----------------------------------------------------------------------------------------
    }
}
