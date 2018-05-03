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
    class Start
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Start - This function starts the UDP listener listening for incoming data.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerUdpListenerStart()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4464;

            ServerLibrary.ServerListenerUDP listener = new ServerListenerUDP(config);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            listener.Start();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
