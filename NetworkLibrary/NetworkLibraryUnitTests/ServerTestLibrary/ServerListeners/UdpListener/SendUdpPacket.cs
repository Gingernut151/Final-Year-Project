using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.Listeners.UdpListener
{
    [TestFixture]
    class SendUdpPacket
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Send Udp Packet - This function sends byte[] data from the system onto the net.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerUdpListenerSend()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4463;

            ServerLibrary.ServerListenerUDP listener = new ServerListenerUDP(config);

            byte[] packetData = { 1, 2, 3, 4, 5 };
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4500);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            listener.SendUdpPacket(packetData, endPoint);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
