using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

using SharedLibrary;

namespace ServerLibrary
{
    public abstract class ServerConnection
    {
        protected Object packetListLock = new Object();

        protected List<ServerClient> _clientList;
        protected List<Packet> _packetList;
        protected ISerializer _serializer;
        protected string _connectionName;

        protected Thread _acceptClientThread;
        protected Thread _checkForPacketsThread;

        protected bool _collectPackets;
        protected bool _accpetClients;
        //-----------------------------------------------------------------------------------------

        public abstract void AddSerializer(ISerializer serializer);
        public abstract void StopListener();
        public abstract void Start();
        public abstract void Stop();
        public abstract void ClearMessages();
        public abstract void ClearMessage(int position);
        public abstract List<Packet> RecieveMessages();
        public abstract void SendPacketToAll(Packet packet);
        public abstract void SendPacketToClient(Packet packet, string clientName);
        public abstract string GetConnectionName();
        public abstract List<ServerClient> GetClientList();
        public abstract void RemoveClient(string name);
    }
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public class ServerConnectionTCP : ServerConnection
    {
        private ServerListenerTCP _listener;
        //-----------------------------------------------------------------------------------------
        public ServerConnectionTCP(string connectionName)
        {
            _clientList = new List<ServerClient>();
            _packetList = new List<Packet>();

            _connectionName = connectionName;

            _collectPackets = false;
            _accpetClients = false;
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
        public override void StopListener()
        {
            _listener.Stop();
        }
        //-----------------------------------------------------------------------------------------
        public override void Start()
        {
            _listener.Start();

            _collectPackets = true;
            _checkForPacketsThread = new Thread(new ThreadStart(this.AcceptPackets));
            _checkForPacketsThread.Start();
        }
        //-----------------------------------------------------------------------------------------
        public override void Stop()
        {
            try
            {
                _accpetClients = false;
                _listener.Stop();

                if (_checkForPacketsThread.IsAlive == true)
                {
                    _checkForPacketsThread.Abort();
                }

                if (_acceptClientThread.IsAlive == true)
                {
                    
                    _acceptClientThread.Abort();
                }

                for (int i = 0; i < _clientList.Count(); i++)
                {
                    _clientList[i].Stop();
                    _clientList.RemoveAt(i);
                }
            }
            catch
            {

            }
        }
        //-----------------------------------------------------------------------------------------
        public void AcceptClients()
        {
            _accpetClients = true;
            _acceptClientThread = new Thread(new ThreadStart(this.FindClients));
            _acceptClientThread.Start();
        }
        //-----------------------------------------------------------------------------------------
        private void FindClients()
        {
            while (_accpetClients == true)
            {
                _listener.AcceptSocket();
                CreateNewTcpClient(_listener.GetSocket().LocalEndPoint.ToString());
            }
        }
        //-----------------------------------------------------------------------------------------
        private void CreateNewTcpClient(string username)
        {
            Socket socket = _listener.GetSocket();

            TCPClient client = new TCPClient(socket, username);
            client.AddSerializer(_serializer);
            client.AddListener(_listener);
            client.Start();
            _clientList.Add(client);

            Console.WriteLine("TCP Client has connected: " + username);
        }
        //-----------------------------------------------------------------------------------------
        public override string GetConnectionName()
        {
            return _connectionName;
        }
        //-----------------------------------------------------------------------------------------
        private void AcceptPackets()
        {
            while (_collectPackets == true)
            {
                for (int i = 0; i < _clientList.Count(); i++)
                {
                    GetTcpPackets((TCPClient)_clientList[i]);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        private void GetTcpPackets(TCPClient client)
        {
            try
            {
                Socket socket = client._socket;
                NetworkStream stream = client._stream;
                BinaryReader reader = client._reader;
                BinaryWriter writer = client._writer;

                if (stream.DataAvailable)
                {
                    int noOfIncomingBytes = reader.ReadInt32();

                    byte[] bytes = reader.ReadBytes(noOfIncomingBytes);

                    Packet packet = _serializer.Deserialize(bytes);

                    if (CheckForUsernamePacket(packet))
                    {
                        // no need to add to packetlist because it has been delt with.
                        client._name = packet.sender;
                    }
                    else if (CheckForDisconnect(packet))
                    {
                        RemovingClient(packet.sender);
                    }
                    else
                    {
                        lock (packetListLock)
                        {
                            _packetList.Add(packet);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void ClearMessages()
        {
            lock (packetListLock)
            {
                _packetList.Clear();
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void ClearMessage(int position)
        {
            lock (packetListLock)
            {
                _packetList.RemoveAt(position);
            }
        }
        //-----------------------------------------------------------------------------------------
        public override List<Packet> RecieveMessages()
        {
            lock (packetListLock)
            {
                return _packetList;
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void SendPacketToAll(Packet packet)
        {
            for (int i = 0; i < _clientList.Count(); i++)
            {
                _clientList[i].Send(packet);
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void SendPacketToClient(Packet packet, string clientName)
        {
            for (int i = 0; i < _clientList.Count(); i++)
            {
                if (_clientList[i]._name.Equals(clientName))
                {
                    _clientList[i].Send(packet);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public override List<ServerClient> GetClientList()
        {
            return _clientList;
        }
        //-----------------------------------------------------------------------------------------
        private bool CheckForUsernamePacket(Packet packet)
        {
            if (packet.type == PacketType.USERNAME)
            {
                return true;
            }

            return false;
        }
        //-----------------------------------------------------------------------------------------
        private bool CheckForDisconnect(Packet packet)
        {
            if (packet.type == PacketType.DISCONNECT)
            {
                return true;
            }
            return false;
        }
        //-----------------------------------------------------------------------------------------
        public override void RemoveClient(string name)
        {
            DisconnectPacket packet = new DisconnectPacket(name, 0);
            SendPacketToClient(packet, name);
            Thread.Sleep(50);
            RemovingClient(name);
        }

        private void RemovingClient(string name)
        {
            for (int i = 0; i < _clientList.Count(); i++)
            {
                if (_clientList[i]._name.Equals(name))
                {
                    _clientList[i].Stop();
                    _clientList.RemoveAt(i);
                    Console.WriteLine("TCP Client has Disconnected: " + name);
                }
            }
        }
    }


    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------
    public class ServerConnectionUDP : ServerConnection
    {
        private ServerListenerUDP _listener;
        //-----------------------------------------------------------------------------------------
        public ServerConnectionUDP(string connectionName)
        {
            _clientList = new List<ServerClient>();
            _packetList = new List<Packet>();

            _connectionName = connectionName;

            _collectPackets = false;
            _accpetClients = false;
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
        public override void StopListener()
        {
            _listener.Stop();
        }
        //-----------------------------------------------------------------------------------------
        public override void Start()
        {
            _listener.Start();

            _collectPackets = true;
            _checkForPacketsThread = new Thread(new ThreadStart(this.AcceptPackets));
            _checkForPacketsThread.Start();
        }
        //-----------------------------------------------------------------------------------------
        public override void Stop()
        {
            try
            {
                if (_checkForPacketsThread.IsAlive == true)
                {
                    _checkForPacketsThread.Abort();
                }

                if (_acceptClientThread.IsAlive == true)
                {
                    _acceptClientThread.Abort();
                }

                _listener.Stop();

                for (int i = 0; i < _clientList.Count(); i++)
                {
                    _clientList[i].Stop();
                    _clientList.RemoveAt(i);
                }
            }
            catch
            {

            }
        }
        //-----------------------------------------------------------------------------------------
        private void CreateNewUdpClient(string username, IPEndPoint endPoint)
        {
            UDPClient client = new UDPClient(username);
            client.AddSerializer(_serializer);
            client.AddEndPoint(endPoint);
            client.AddListener(_listener);
            client.Start();
            _clientList.Add(client);

            Console.WriteLine("UDP Client has connected: " + endPoint.Address.ToString() + ":" + endPoint.Port.ToString());
        }
        //-----------------------------------------------------------------------------------------
        private bool CheckForNewUser(IPEndPoint remoteClient, string username)
        {
            bool alreadyConnected = false;

            for (int i = 0; i < _clientList.Count(); i++)
            {
                UDPClient client = ((UDPClient)_clientList[i]);

                if (client._remoteClient.Equals(remoteClient))
                {
                    alreadyConnected = true;
                }
            }

            if (alreadyConnected == false)
            {
                CreateNewUdpClient(username, remoteClient);
                return true;
            }

            return false;
        }
        //-----------------------------------------------------------------------------------------
        public override string GetConnectionName()
        {
            return _connectionName;
        }
        //-----------------------------------------------------------------------------------------
        private void AcceptPackets()
        {
            while (_collectPackets == true)
            {
                GetUdpPackets();
            }
        }
        //-----------------------------------------------------------------------------------------
        private void GetUdpPackets()
        {
            UDP_Data udp = _listener.ReceiveUdpPacket();

            byte[] data = udp.buffer;
            bool dealtWith = false;

            if (data != null)
            {
                Packet packet = _serializer.Deserialize(data);
                
                dealtWith = CheckForNewUser(udp.remoteClient, packet.sender);

                if (dealtWith == false)
                {
                    dealtWith = CheckForDisconnect(packet);
                }

                if (dealtWith == false)
                {
                    lock (packetListLock)
                    {
                        _packetList.Add(packet);
                    }
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void ClearMessages()
        {
            lock (packetListLock)
            {
                _packetList.Clear();
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void ClearMessage(int position)
        {
            lock (packetListLock)
            {
                _packetList.RemoveAt(position);
            }
        }
        //-----------------------------------------------------------------------------------------
        public override List<Packet> RecieveMessages()
        {
            lock (packetListLock)
            {
                return _packetList;
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void SendPacketToAll(Packet packet)
        {
            for (int i = 0; i < _clientList.Count(); i++)
            {
                _clientList[i].Send(packet);
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void SendPacketToClient(Packet packet, string clientName)
        {
            for (int i = 0; i < _clientList.Count(); i++)
            {
                if (_clientList[i]._name.Equals(clientName))
                {
                    _clientList[i].Send(packet);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public override List<ServerClient> GetClientList()
        {
            return _clientList;
        }
        //-----------------------------------------------------------------------------------------
        private bool CheckForDisconnect(Packet packet)
        {
            if (packet.type == PacketType.DISCONNECT)
            {
                RemoveClient(packet.sender);
                return true;
            }

            return false;
        }
        //-----------------------------------------------------------------------------------------
        public override void RemoveClient(string name)
        {
            for (int i = 0; i < _clientList.Count(); i++)
            {
                if (_clientList[i]._name.Equals(name))
                {
                    _clientList[i].Stop();
                    _clientList.RemoveAt(i);
                }
            }
        }
    }
}
