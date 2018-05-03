using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.Server
{
    [TestFixture]
    class SendPacketToClient
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Send Tcp Packet To Client - Create a packet and send to the client on the relative connection
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerSendTcpToClient()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4448;

            ServerLibrary.Server server = new ServerLibrary.Server();
            ServerLibrary.ServerConnectionTCP connection = new ServerLibrary.ServerConnectionTCP("Tester");
            ServerListenerTCP listener = new ServerListenerTCP(config);
            connection.AddListener(listener);
            server.AddConnection(connection);
            server.Start();

            ChatMessagePacket packet = new ChatMessagePacket("Hello", "Tester");

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            server.SendPacketToClient(packet, "Tester", "Bob");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------


            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }

        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 2 - Send Udp Packet To Client - Create a packet and send to a client on the relative connection
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void SendUdpToClient()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4440;

            ServerLibrary.Server server = new ServerLibrary.Server();
            ServerLibrary.ServerConnectionUDP connection = new ServerLibrary.ServerConnectionUDP("TesterUdpClient");
            ServerListenerUDP listener = new ServerListenerUDP(config);
            connection.AddListener(listener);
            server.AddConnection(connection);
            server.Start();

            ChatMessagePacket packet = new ChatMessagePacket("Hello", "Tester");

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            server.SendPacketToClient(packet, "TesterUdpClient", "Bob");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------


            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
