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
    class ClearDataPackets
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Clear Data Packets - This will empty the queue of data packets stored on this connection.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientConnectionTcpClearDataPackets()
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
            connection.AddSerializer(serializer);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            connection.ClearDataPackets();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
