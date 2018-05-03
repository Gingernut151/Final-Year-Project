using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.ServerConnection
{
    [TestFixture]
    class AddListener
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Add Listener - This will add the Listener
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerConnectionAddListener()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4492;

            ServerListenerUDP listener = new ServerListenerUDP(config);
            ServerLibrary.ServerConnectionUDP connection = new ServerLibrary.ServerConnectionUDP("Tester");

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            connection.AddListener(listener);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
