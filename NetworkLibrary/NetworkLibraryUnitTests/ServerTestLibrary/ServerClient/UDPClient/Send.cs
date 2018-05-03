using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.ServerClient.UDPClient
{
    [TestFixture]
    class Send
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Send - Sends a Udp packet onto the network
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerUdpClientSend()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------

            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4486;

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4485);
            ServerListenerUDP listener = new ServerListenerUDP(config);
            DotNetserialization serializer = new DotNetserialization();
            ServerLibrary.UDPClient client = new ServerLibrary.UDPClient("Tester");
            client.AddSerializer(serializer);
            client.AddEndPoint(endPoint);
            client.AddListener(listener);

            ChatMessagePacket packet = new ChatMessagePacket("This is a test", "Tester");

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            client.Send(packet);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
