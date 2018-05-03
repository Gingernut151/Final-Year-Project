using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.ServerConnection
{
    [TestFixture]
    class Stop
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Stop - This will end any threads and call stop no the clients
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerConnectionStop()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 3513;

            ServerListenerUDP listener = new ServerListenerUDP(config);
            ServerLibrary.ServerConnectionUDP connection = new ServerLibrary.ServerConnectionUDP("Tester");
            connection.AddListener(listener);
            connection.Start();

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            connection.Stop();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
