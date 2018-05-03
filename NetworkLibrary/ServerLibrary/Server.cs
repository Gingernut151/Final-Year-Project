using System;
using System.Collections.Generic;
using System.Linq;

using SharedLibrary;

namespace ServerLibrary
{
    public class Server
    {
        List<ServerConnection> _connection;
        //-----------------------------------------------------------------------------------------
        public Server()
        {
            _connection = new List<ServerConnection>();
        }
        //-----------------------------------------------------------------------------------------
        public void AddConnection(ServerConnection connection)
        {
            _connection.Add(connection);
        }
        //-----------------------------------------------------------------------------------------
        public void RemoveConnection(string connectionName)
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                if (_connection[i].GetConnectionName().Equals(connectionName))
                {
                    _connection[i].Stop();
                    _connection.RemoveAt(i);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public List<ServerClient> GetConnectionClientList(string connectionName)
        {
            List<ServerClient> clientList = new List<ServerClient>();

            for (int i = 0; i < _connection.Count(); i++)
            {
                if (_connection[i].GetConnectionName().Equals(connectionName))
                {
                    return _connection[i].GetClientList();
                }
            }

            return clientList;
        }
        //-----------------------------------------------------------------------------------------
        public void RemoveClient(string connectionName, string username)
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                if (_connection[i].GetConnectionName().Equals(connectionName))
                {
                    _connection[i].RemoveClient(username);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public void Start()
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                _connection[i].Start();
            }
        }
        //-----------------------------------------------------------------------------------------
        public void Stop()
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                _connection[i].Stop();
                _connection.RemoveAt(i);
            }
        }
        //-----------------------------------------------------------------------------------------
        public void AllowTcpConnection(string connectionName)
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                if (_connection[i].GetConnectionName().Equals(connectionName))
                {
                    ((ServerConnectionTCP)_connection[i]).AcceptClients();
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public void SendPacketToAll(Packet packet, string connectionName)
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                if (_connection[i].GetConnectionName().Equals(connectionName))
                {
                    _connection[i].SendPacketToAll(packet);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public void SendPacketToClient(Packet packet, string connectionName, string clientName)
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                if (_connection[i].GetConnectionName().Equals(connectionName))
                {
                    _connection[i].SendPacketToClient(packet, clientName);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public List<Packet> RecieveMessages(string connectionName)
        {
            List<Packet> packets = new List<Packet>();

            for (int i = 0; i < _connection.Count(); i++)
            {
                if (_connection[i].GetConnectionName().Equals(connectionName))
                {
                    packets = _connection[i].RecieveMessages();
                }
            }
            return packets;
        }
        //-----------------------------------------------------------------------------------------
        public void ClearMessages(string connectionName)
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                if (_connection[i].GetConnectionName().Equals(connectionName))
                {
                    _connection[i].ClearMessages();
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public void ClearMessage(string connectionName, int position)
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                if (_connection[i].GetConnectionName().Equals(connectionName))
                {
                    _connection[i].ClearMessage(position);
                }
            }
        }
    }
}
