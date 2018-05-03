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
    public class SendPacketToAll
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Send Tcp Packet To All - Create a packet and send to the relative connection
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerSendTcpToAll()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4447;

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
            server.SendPacketToAll(packet, "Tester");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------
            

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
            
        }

        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 2 - Send Udp Packet To All - Create a packet and send to all on the relative connection
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void SendUdpToAll()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4449;

            ServerLibrary.Server server = new ServerLibrary.Server();
            ServerLibrary.ServerConnectionUDP connection = new ServerLibrary.ServerConnectionUDP("TesterUdpAll");
            ServerListenerUDP listener = new ServerListenerUDP(config);
            connection.AddListener(listener);
            server.AddConnection(connection);
            server.Start();

            ChatMessagePacket packet = new ChatMessagePacket("Hello", "Tester");

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            server.SendPacketToAll(packet, "TesterUdpAll");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------


            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
