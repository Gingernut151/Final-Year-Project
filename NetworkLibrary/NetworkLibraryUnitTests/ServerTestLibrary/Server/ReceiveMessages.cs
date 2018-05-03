using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.Server
{
    [TestFixture]
    public class ReceiveMessages
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Recieve Meassages - Collect the packet list
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerCollectionOfPackets()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4450;

            ServerLibrary.Server server = new ServerLibrary.Server();
            ServerLibrary.ServerConnectionTCP connection = new ServerLibrary.ServerConnectionTCP("Tester");
            ServerListenerTCP listener = new ServerListenerTCP(config);
            connection.AddListener(listener);
            server.AddConnection(connection);
            server.Start();

            List<Packet> expecetedPackets = new List<Packet>();

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            List<Packet> packets = server.RecieveMessages("Tester");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
            Assert.AreEqual(expecetedPackets, packets);
        }
    }
}
