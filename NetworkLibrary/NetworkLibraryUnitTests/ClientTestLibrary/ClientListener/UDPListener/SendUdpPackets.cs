using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ClientTestLibrary.ClientListener.UDPListener
{
    [TestFixture]
    class SendUdpPackets
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Send Packet - This will send the packet over the net.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientListenerUdpSendPackets()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4518;

            ClientLibrary.ClientListenerUDP listener = new ClientLibrary.ClientListenerUDP(config);
            listener.Start();

            byte[] packetData = { 1, 2, 3, 4, 5 };
            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            listener.SendUdpPacket(packetData);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
