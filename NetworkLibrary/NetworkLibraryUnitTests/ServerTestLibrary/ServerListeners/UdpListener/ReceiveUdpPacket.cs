using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.Listeners.UdpListener
{
    [TestFixture]
    class ReceiveUdpPacket
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Receive Udp Packet - This function checks for incoming data and passes it into the system.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerUdpListenerReceiveUdpPackets()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4462;

            ServerLibrary.ServerListenerUDP listener = new ServerListenerUDP(config);

            UDP_Data incomingData;

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            incomingData = listener.ReceiveUdpPacket();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
