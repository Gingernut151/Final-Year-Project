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
    class Stop
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Stop - This function stops the UDP listener listening for incoming data
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerUdpListenerStop()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4465;

            ServerLibrary.ServerListenerUDP listener = new ServerListenerUDP(config);
            listener.Start();

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            listener.Stop();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
