using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using SharedLibrary;
using ServerLibrary;

namespace FYP_Server
{
    class MatchServer
    {
        public static float sendRate = 40.0f;
        public static Protocol protocol = Protocol.UDP;
        public static PacketSize packetSize = PacketSize.LARGE;

        float deltaTime = 0.0f;
        HiResTimer timer;

        List<playerGameData> clientsConnected = new List<playerGameData>();
        Server _server;

        Vec3 defaultVec3 = new Vec3();
        Vec4 defaultVec4 = new Vec4();

        int currentPacketAmount = 0;
        int currentPacketsReceived = 0;
        int currentPacketIndexIncoming = 0;
        int currentPacketIndexOutgoing = 0;

        public void InitMatch(List<playerLobbyData> clients)
        {
            defaultVec3.x = 0.0f;
            defaultVec3.y = 0.0f;
            defaultVec3.z = 0.0f;

            defaultVec4.x = 0.0f;
            defaultVec4.y = 0.0f;
            defaultVec4.z = 0.0f;

            for (int i = 0; i < clients.Count; i++)
            {
                playerGameData client;
                client.address = clients[i].address;
                client.username = clients[i].username;
                client.position = defaultVec3;
                client.rotation = defaultVec4;

                clientsConnected.Add(client);
            }

            InitConnection();
            timer = new HiResTimer();
        }
        private void InitConnection()
        {
            if (protocol == Protocol.UDP)
            {
                UDP_Config udp_Config;
                udp_Config.address = "0.0.0.0"; // "127.0.0.1"; //
                udp_Config.port = 5555;

                ServerListenerUDP udpListener = new ServerListenerUDP(udp_Config);
                ProtoBufSerializer udpSerialize = new ProtoBufSerializer();
                ServerConnectionUDP udpConnection = new ServerConnectionUDP("Udp_Game");
                udpConnection.AddListener(udpListener);
                udpConnection.AddSerializer(udpSerialize);

                _server = new Server();
                _server.AddConnection(udpConnection);
            }
            else
            {
                TCP_Config tcp_Config;
                tcp_Config.address = "0.0.0.0"; // "127.0.0.1"; //
                tcp_Config.port = 6666;

                ServerListenerTCP tcpListener = new ServerListenerTCP(tcp_Config);
                ProtoBufSerializer tcpSerialize = new ProtoBufSerializer();
                ServerConnectionTCP tcpConnection = new ServerConnectionTCP("Udp_Game");
                tcpConnection.AddListener(tcpListener);
                tcpConnection.AddSerializer(tcpSerialize);

                _server = new Server();
                _server.AddConnection(tcpConnection);
            }
        }

        public void StartMatch()
        {
            _server.Start();

            if (Protocol.TCP == protocol)
            {
                _server.AllowTcpConnection("Udp_Game");
            }
        }

        public void UpdateMatch()
        {
            while (true)
            {
                CalculateDeltaTime();
                HandleGameMessagesIncoming();
            }
        }

        private void HandleGameMessagesIncoming()
        {
            try
            {
                List<Packet> packetList = _server.RecieveMessages("Udp_Game");
                currentPacketAmount = packetList.Count;

                if (currentPacketAmount > 0)
                {
                    currentPacketsReceived++;
                    Packet packet = packetList[0];

                    HandlePacketMisses(packet.index, packet.type);

                    if (packet.type == PacketType.PING)
                    {
                        PrintData();
                        _server.ClearMessage("Udp_Game", 0);
                    }
                    else if (packetList[0].type == PacketType.PLAYERPOS)
                    {
                        Vec3 pos = ((PlayerPosPacket)packet).position;
                        Vec4 rot = ((PlayerPosPacket)packet).rotation;
                        string sender = ((PlayerPosPacket)packet).sender;

                        for (int i = 0; i < clientsConnected.Count; i++)
                        {
                            if (sender.Equals(clientsConnected[i].username))
                            {
                                playerGameData data = clientsConnected[i];
                                data.username = clientsConnected[i].username;
                                data.position = pos;
                                data.rotation = rot;
                                clientsConnected[i] = data;
                            }
                        }
                        _server.ClearMessage("Udp_Game", 0);
                    }
                }
            }
            catch
            { }
        }

        private void HandleGameMessagesOutgoing()
        {
            if (packetSize == PacketSize.LARGE)
            {
                HandleLargeMessagesOutgoing();
            }
            else if (packetSize == PacketSize.MEDIUM)
            {
                HandleMediumMessagesOutgoing();
            }
            else
            {
                HandleSmallMessagesOutgoing();
            }
        }

        private void HandleLargeMessagesOutgoing()
        {
            LargePlayerData[] lobbyData = new LargePlayerData[10];

            if (clientsConnected.Count > 0)
            {
                for (int i = 0; i < clientsConnected.Count; i++)
                {
                    lobbyData[i].playerAddress = clientsConnected[i].username;
                    lobbyData[i].position = clientsConnected[i].position;
                    lobbyData[i].rotation = clientsConnected[i].rotation;
                    lobbyData[i].isCrouching = false;
                    lobbyData[i].stanima = 5;
                    lobbyData[i].lookingDirection = defaultVec3;
                    lobbyData[i].health = 5;
                }

                for (int i = clientsConnected.Count; i < lobbyData.Count(); i++)
                {
                    lobbyData[i].playerAddress = "-------------";
                    lobbyData[i].position = defaultVec3;
                    lobbyData[i].rotation = defaultVec4;
                    lobbyData[i].isCrouching = false;
                    lobbyData[i].stanima = 5;
                    lobbyData[i].lookingDirection = defaultVec3;
                    lobbyData[i].health = 5;
                }

                LargeAllPlayerPosPacket packet = new LargeAllPlayerPosPacket("Server", lobbyData, currentPacketIndexOutgoing++);
                _server.SendPacketToAll(packet, "Udp_Game");
            }
        }
        private void HandleMediumMessagesOutgoing()
        {
            LargePlayerData[] lobbyData = new LargePlayerData[5];

            if (clientsConnected.Count > 0)
            {
                for (int i = 0; i < clientsConnected.Count; i++)
                {
                    lobbyData[i].playerAddress = clientsConnected[i].username;
                    lobbyData[i].position = clientsConnected[i].position;
                    lobbyData[i].rotation = clientsConnected[i].rotation;
                    lobbyData[i].isCrouching = false;
                    lobbyData[i].stanima = 5;
                    lobbyData[i].lookingDirection = defaultVec3;
                    lobbyData[i].health = 5;
                }

                for (int i = clientsConnected.Count; i < lobbyData.Count(); i++)
                {
                    lobbyData[i].playerAddress = "-------------";
                    lobbyData[i].position = defaultVec3;
                    lobbyData[i].rotation = defaultVec4;
                    lobbyData[i].isCrouching = false;
                    lobbyData[i].stanima = 5;
                    lobbyData[i].lookingDirection = defaultVec3;
                    lobbyData[i].health = 5;
                }

                LargeAllPlayerPosPacket packet = new LargeAllPlayerPosPacket("Server", lobbyData, currentPacketIndexOutgoing++);
                _server.SendPacketToAll(packet, "Udp_Game");
            }
        }
        private void HandleSmallMessagesOutgoing()
        {
            PlayerData[] lobbyData = new PlayerData[100];

            if (clientsConnected.Count > 0)
            {
                for (int i = 0; i < clientsConnected.Count; i++)
                {
                    lobbyData[i].playerAddress = clientsConnected[i].username;
                    lobbyData[i].position = clientsConnected[i].position;
                    lobbyData[i].rotation = clientsConnected[i].rotation;
                }

                for (int i = clientsConnected.Count; i < lobbyData.Count(); i++)
                {
                    lobbyData[i].playerAddress = "-------------";
                    lobbyData[i].position = defaultVec3;
                    lobbyData[i].rotation = defaultVec4;
                }

                AllPlayerPosPacket packet = new AllPlayerPosPacket("Server", lobbyData, currentPacketIndexOutgoing++);
                _server.SendPacketToAll(packet, "Udp_Game");
            }
        }

        private void HandlePacketMisses(int index, PacketType type)
        {
            if (index != currentPacketIndexIncoming + 1)
            {
                if (index < currentPacketIndexIncoming)
                {
                    TestResults.IncrementPacketsMissed(type);
                }
                else
                {
                    TestResults.IncrementPacketsLate(type);
                    currentPacketIndexIncoming = index;
                }
            }
            else
            {
                currentPacketIndexIncoming = index;
            }
        }

        private void CalculateDeltaTime()
        {
            timer.Stop();
            deltaTime += ((timer.Duration() * 5.0f) / 1000.0f);
            timer.Reset();
            timer.Start();

            if (deltaTime > (1.0f / sendRate))
            {
                deltaTime = 0.0f;
                HandleGameMessagesOutgoing();
            }

        }

        public void PrintData()
        {
            TestResults.WriteOutFile( (int)sendRate, currentPacketAmount, protocol.ToString(), currentPacketIndexOutgoing, currentPacketsReceived);
        }
    }
}
