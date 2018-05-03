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
    class CollectDataPackets
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Collect Data Packets - This will return the queue of data packets on this connection
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientConnectionTcpCollectDataPackets()
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

            List<Packet> packets;

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            packets = connection.CollectDataPackets();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
