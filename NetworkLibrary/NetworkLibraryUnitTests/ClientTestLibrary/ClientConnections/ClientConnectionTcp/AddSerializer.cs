using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ClientLibrary;

namespace NetworkLibraryUnitTests.ClientTestLibrary.ClientConnections.ClientConnectionTcp
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
        public void ClientConnectionTcpAddSerializer()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4500;

            DotNetserialization serializer = new DotNetserialization();
            ClientLibrary.ClientListenerTCP listener = new ClientLibrary.ClientListenerTCP(config);
            ClientLibrary.ClientConnectionTCP connection = new ClientLibrary.ClientConnectionTCP("Test_Connection", "Tester");
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
