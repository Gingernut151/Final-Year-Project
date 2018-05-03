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
    class ClientListenerUdp
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - ClientListenerUdp Constructor - This is the constructor of the Server UDP Listener
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientListenerUdpConstructor()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4514;

            ClientLibrary.ClientListenerUDP listener;

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            listener = new ClientLibrary.ClientListenerUDP(config);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
