using System;
using ProtoBuf;
using System.Net;

namespace SharedLibrary
{
    public enum Protocol
    {
        TCP,
        UDP
    }

    public enum PacketSize
    {
        LARGE,
        MEDIUM,
        SMALL
    }

    public enum PacketType
    {
        EMPTY,
        USERNAME,
        CHATMESSAGE,
        DISCONNECT,
        LOBBY,
        PING,
        LOBBYREADY,
        PLAYERPOS,
        LARGEPLAYERPOS,
        ALLPLAYERPOS,
        LARGEALLPLAYERPOS,
        CUSTOM
    }

    [Serializable]
    [ProtoContract]
    public struct LobbyData
    {
        [ProtoMember(1)]
        public string playerAddress;
        [ProtoMember(2)]
        public bool isPlayer;
        [ProtoMember(3)]
        public int ping;
        [ProtoMember(4)]
        public bool isReady;
    }

    [Serializable]
    [ProtoContract]
    public struct Vec3
    {
        [ProtoMember(5)]
        public float x;
        [ProtoMember(6)]
        public float y;
        [ProtoMember(7)]
        public float z;
    }

    [Serializable]
    [ProtoContract]
    public struct Vec4
    {
        [ProtoMember(22)]
        public float x;
        [ProtoMember(23)]
        public float y;
        [ProtoMember(24)]
        public float z;
        [ProtoMember(25)]
        public float w;
    }

    [Serializable]
    [ProtoContract]
    public struct PlayerData
    {
        [ProtoMember(8)]
        public string playerAddress;
        [ProtoMember(9)]
        public Vec3 position;
        [ProtoMember(10)]
        public Vec4 rotation;
    }

    [Serializable]
    [ProtoContract]
    public struct LargePlayerData
    {
        [ProtoMember(8)]
        public string playerAddress;
        [ProtoMember(9)]
        public Vec3 position;
        [ProtoMember(10)]
        public Vec4 rotation;
        [ProtoMember(30)]
        public bool isCrouching;
        [ProtoMember(31)]
        public Vec3 lookingDirection;
        [ProtoMember(32)]
        public decimal bulletCount;
        [ProtoMember(33)]
        public decimal health;
        [ProtoMember(34)]
        public decimal stanima;
        [ProtoMember(35)]
        public decimal Armour;
    }

    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    [ProtoInclude(100, typeof(ChatMessagePacket))]
    [ProtoInclude(101, typeof(UsernamePacket))]
    [ProtoInclude(102, typeof(DisconnectPacket))]
    [ProtoInclude(103, typeof(UdpConnectPacket))]
    [ProtoInclude(104, typeof(ClientListPacket))]
    [ProtoInclude(105, typeof(LobbyPacket))]
    [ProtoInclude(106, typeof(PingNumPacket))]
    [ProtoInclude(107, typeof(LobbyReadyPacket))]
    [ProtoInclude(108, typeof(PlayerPosPacket))]
    [ProtoInclude(109, typeof(LargePlayerPosPacket))]
    [ProtoInclude(110, typeof(AllPlayerPosPacket))]
    [ProtoInclude(111, typeof(LargeAllPlayerPosPacket))]

    public abstract class Packet
    {
        [ProtoMember(11)]
        public PacketType type = PacketType.EMPTY;
        [ProtoMember(12)]
        public string sender = string.Empty;
        [ProtoMember(26)]
        public int index = 0;
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class ChatMessagePacket : Packet
    {
        [ProtoMember(13)]
        public string message = String.Empty;
        public ChatMessagePacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.CHATMESSAGE;
            this.message = "This is defualt constructed";
            this.sender = "Defualt";
            this.index = 0;
        }

        public ChatMessagePacket(string message, string sender, int index)
        {
            this.index = index;
            this.type = PacketType.CHATMESSAGE;
            this.message = message;
            this.sender = sender;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class UsernamePacket : Packet
    {
        public UsernamePacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.USERNAME;
            this.sender = "Defualt";
            this.index = 0;
        }
        public UsernamePacket(string username, int index)
        {
            this.index = index;
            this.type = PacketType.USERNAME;
            this.sender = username;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class DisconnectPacket : Packet
    {
        public DisconnectPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.DISCONNECT;
            this.sender = "Defualt";
            this.index = 0;
        }
        public DisconnectPacket(string username, int index)
        {
            this.index = index;
            this.type = PacketType.DISCONNECT;
            this.sender = username;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class UdpConnectPacket : Packet
    {
        [ProtoMember(14)]
        public string address = String.Empty;
        public UdpConnectPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.DISCONNECT;
            this.sender = "Defualt";
            this.address = "192.168.1.1";
            this.index = 0;
        }
        public UdpConnectPacket(string username, string address, int index)
        {
            this.index = index;
            this.type = PacketType.DISCONNECT;
            this.sender = username;
            this.address = address;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class ClientListPacket : Packet
    {
        [ProtoMember(15)]
        public string[] playerNames = new string[10];
        public ClientListPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.DISCONNECT;
            this.sender = "Defualt";
            this.index = 0;

            for (int i = 0; i < playerNames.Length; i++)
            {
                this.playerNames[1] = "Unknown";
            }
        }
        public ClientListPacket(string username, string[] users, int index)
        {
            this.index = index;
            this.type = PacketType.DISCONNECT;
            this.sender = username;
            this.playerNames = users;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class LobbyPacket : Packet
    {
        [ProtoMember(16)]
        public LobbyData[] data;
        public LobbyPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.LOBBY;
            this.sender = "Defualt";
            this.index = 0;
        }
        public LobbyPacket(string username, LobbyData[] lobbyData, int index)
        {
            this.index = index;
            this.type = PacketType.LOBBY;
            this.sender = username;
            this.data = lobbyData;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class PingNumPacket : Packet
    {
        [ProtoMember(17)]
        public long ping;
        public PingNumPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.PING;
            this.sender = "Defualt";
            this.index = 0;
        }
        public PingNumPacket(string username, long newPing, int index)
        {
            this.index = index;
            this.type = PacketType.PING;
            this.sender = username;
            this.ping = newPing;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class LobbyReadyPacket : Packet
    {
        [ProtoMember(18)]
        public bool isReady;
        [ProtoMember(27)]
        public string serverTickrate;
        [ProtoMember(28)]
        public string testName;
        [ProtoMember(29)]
        public Protocol protocol;
        [ProtoMember(39)]
        public PacketSize packetSize;

        public LobbyReadyPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.LOBBYREADY;
            this.sender = "Defualt";
            this.index = 0;
            this.isReady = false;
            this.serverTickrate = "60";
            this.testName = "Test";
        }
        public LobbyReadyPacket(string username, bool isReady, int index, string serverTickrate, string testName, Protocol protocol, PacketSize packetSize)
        {
            this.index = index;
            this.type = PacketType.LOBBYREADY;
            this.sender = username;
            this.isReady = isReady;
            this.serverTickrate = serverTickrate;
            this.testName = testName;
            this.protocol = protocol;
            this.packetSize = packetSize;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class PlayerPosPacket : Packet
    {
        [ProtoMember(18)]
        public Vec3 position;
        [ProtoMember(20)]
        public Vec4 rotation;
        public PlayerPosPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.PLAYERPOS;
            this.sender = "Defualt";
            this.index = 0;
        }
        public PlayerPosPacket(string username, Vec3 position, Vec4 rotation, int index)
        {
            this.index = index;
            this.type = PacketType.PLAYERPOS;
            this.sender = username;
            this.position = position;
            this.rotation = rotation;
        }
    }   
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class LargePlayerPosPacket : Packet
    {
        [ProtoMember(37)]
        public LargePlayerData data;
        public LargePlayerPosPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.LARGEPLAYERPOS;
            this.sender = "Defualt";
            this.index = 0;
        }
        public LargePlayerPosPacket(string username, LargePlayerData data, int index)
        {
            this.index = index;
            this.type = PacketType.LARGEPLAYERPOS;
            this.sender = username;
            this.data = data;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class AllPlayerPosPacket : Packet
    {
        [ProtoMember(21)]
        public PlayerData[] players;

        public AllPlayerPosPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.PLAYERPOS;
            this.sender = "Defualt";
            this.index = 0;
        }
        public AllPlayerPosPacket(string username, PlayerData[] data, int index)
        {
            this.index = index;
            this.type = PacketType.PLAYERPOS;
            this.sender = username;
            this.players = data;
        }
    }
    //-----------------------------------------------------------------------------------------
    [Serializable]
    [ProtoContract]
    public class LargeAllPlayerPosPacket : Packet
    {
        [ProtoMember(36)]
        public LargePlayerData[] players;

        public LargeAllPlayerPosPacket() // Protobuf requires a base constructor
        {
            this.type = PacketType.LARGEALLPLAYERPOS;
            this.sender = "Defualt";
            this.index = 0;
        }
        public LargeAllPlayerPosPacket(string username, LargePlayerData[] data, int index)
        {
            this.index = index;
            this.type = PacketType.LARGEALLPLAYERPOS;
            this.sender = username;
            this.players = data;
        }
    }
}
