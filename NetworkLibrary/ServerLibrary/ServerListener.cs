using System;
using System.Net;
using System.Net.Sockets;

using SharedLibrary;

namespace ServerLibrary
{
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public abstract class ServerListener
    {
       public abstract void Start();
       public abstract void Stop();
    }
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public class ServerListenerTCP : ServerListener
    {
        TCP_Config _config;
        TcpListener _listener;
        Socket _socket;
        //-----------------------------------------------------------------------------------------
        public ServerListenerTCP (TCP_Config config)
        {
            _config = config;

            IPAddress ip = IPAddress.Parse(_config.address);
            _listener = new TcpListener(ip, _config.port);
        }
        //-----------------------------------------------------------------------------------------
        public override void Start()
        {
            _listener.Start();
            Console.WriteLine("Server listening on: " + _config.address + ":" + _config.port.ToString());
        }
        //-----------------------------------------------------------------------------------------
        public override void Stop()
        {
            _listener.Stop();
        }
        //-----------------------------------------------------------------------------------------
        public Socket GetSocket()
        {
           return _socket;
        }
        //-----------------------------------------------------------------------------------------
        public void AcceptSocket()
        {
            _socket = _listener.AcceptSocket();
        }
        //-----------------------------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public class ServerListenerUDP : ServerListener
    {
        UDP_Config _config;
        UdpClient _listener;
        IPEndPoint remoteClient;
        IPEndPoint localClient;
        //-----------------------------------------------------------------------------------------
        public ServerListenerUDP(UDP_Config config)
        {
            _config = config;

            localClient = new IPEndPoint(IPAddress.Any, _config.port);
            remoteClient = new IPEndPoint(IPAddress.Any, 0);
            _listener = new UdpClient(localClient);
            _listener.EnableBroadcast = false;
        }
        //-----------------------------------------------------------------------------------------
        public override void Start()
        {
            _listener.EnableBroadcast = true;
            Console.WriteLine("Server listening on: " + _config.address + ":" + _config.port.ToString());
        }
        //-----------------------------------------------------------------------------------------
        public override void Stop()
        {
            _listener.Close();
        }
        //-----------------------------------------------------------------------------------------
        public UDP_Data ReceiveUdpPacket()
        {
            UDP_Data udpData = new UDP_Data();

            udpData.buffer = _listener.Receive(ref remoteClient);
            udpData.remoteClient = remoteClient;

            return udpData;
        }
        //-----------------------------------------------------------------------------------------
        public void SendUdpPacket(byte[] packetData, IPEndPoint clientEndpoint)
        {
            _listener.Send(packetData, packetData.Length, clientEndpoint);
        }
        //-----------------------------------------------------------------------------------------
    }
}
