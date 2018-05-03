using System;
using System.Collections.Generic;
using System.Linq;

using SharedLibrary;

namespace ClientLibrary
{
    public class Client
    {
        private string _name;
        private List<ClientConnection> _connection;
        //-----------------------------------------------------------------------------------------
        public Client(string name)
        {
            _name = name;
            _connection = new List<ClientConnection>();
        }
        //-----------------------------------------------------------------------------------------
        public void AddConnection(ClientConnection connection)
        {
            _connection.Add(connection);
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
            }
        }
        //-----------------------------------------------------------------------------------------
        public void SendMessage(Packet packet, string connectionName)
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                if(connectionName.Equals(_connection[i].GetConnectionName()))
                {
                   _connection[i].Send(packet);
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public List<Packet> RecieveMessages(string connectionName)
        {
            List<Packet> packetList = new List<Packet>();

            for (int i = 0; i < _connection.Count(); i++)
            {
                if (connectionName.Equals(_connection[i].GetConnectionName()))
                {
                    packetList = _connection[i].CollectDataPackets();
                }
            }

            return packetList;
        }
        //-----------------------------------------------------------------------------------------
        public void ClearMessages(String connectionName)
        {
            for (int i = 0; i < _connection.Count(); i++)
            {
                if (connectionName.Equals(_connection[i].GetConnectionName()))
                {
                    _connection[i].ClearDataPackets();
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        public void ChangeUsername(String connectionName, String username)
        {
            _name = username;

            for (int i = 0; i < _connection.Count(); i++)
            {
                _connection[i].ChangeUsername(username);
            }
        }
        //-----------------------------------------------------------------------------------------
        public string GetUsername()
        {
            return _name;
        
        }
        //-----------------------------------------------------------------------------------------
    }
}
