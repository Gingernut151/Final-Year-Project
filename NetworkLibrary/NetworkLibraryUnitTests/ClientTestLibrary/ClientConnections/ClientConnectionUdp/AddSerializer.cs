using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ClientLibrary;

namespace NetworkLibraryUnitTests.ClientTestLibrary.ClientConnections.ClientConnectionUDP
{
    [TestFixture]
    class AddSerializer
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Add Serializer - This will add a listener to the connection.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientConnectionUdpAddSerializer()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4526;

            DotNetserialization serializer = new DotNetserialization();
            ClientLibrary.ClientListenerUDP listener = new ClientLibrary.ClientListenerUDP(config);
            ClientLibrary.ClientConnectionUDP connection = new ClientLibrary.ClientConnectionUDP("Test_Connection", "Tester");
            connection.AddListener(listener);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            connection.AddSerializer(serializer);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
