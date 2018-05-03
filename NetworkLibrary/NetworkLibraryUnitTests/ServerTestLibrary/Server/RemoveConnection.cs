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
    public class RemoveConnection
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Remove Connection - If no valid referenced list is returned; there no connection is found and
        //                           thus means that there is no connection.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerRemovalOfConnection()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4445;

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
            server.RemoveConnection("Tester");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------
            List<Packet> packets = server.RecieveMessages("Tester");

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
            Assert.AreEqual(expecetedPackets, packets);
        }
    }
}
