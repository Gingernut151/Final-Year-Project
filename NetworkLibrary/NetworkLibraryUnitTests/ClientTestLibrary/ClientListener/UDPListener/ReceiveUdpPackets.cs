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
    class ReceiveUdpPackets
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Receive Packets - This will wait for incoming data and return it to the library.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientListenerUdpReceivePackets()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4517;

            ClientLibrary.ClientListenerUDP listener = new ClientLibrary.ClientListenerUDP(config);
            listener.Start();

            byte[] incomingData;

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            incomingData = listener.ReceiveUdpPackets();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
