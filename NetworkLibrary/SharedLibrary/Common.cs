using System;
using System.Net;

namespace SharedLibrary
{
    public struct TCP_Config
    {
        public String address;
        public int port;
    }
    //-----------------------------------------------------------------------------------------
    public struct UDP_Config
    {
        public string address;
        public int port;
    }
    //-----------------------------------------------------------------------------------------
    public enum CONNECTION_TYPE
    {
        TCP,
        UDP
    }
    //-----------------------------------------------------------------------------------------
    public struct UDP_Data
    {
        public byte[] buffer;
        public IPEndPoint remoteClient;
        public string username;
    }
    //-----------------------------------------------------------------------------------------
}
