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
    class AddConnection
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Add Connection - If the packts list that is returned is not null then the connection has
        //                           been added and is findable by the recieveMessages function.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerAddConnection()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ServerLibrary.Server server = new ServerLibrary.Server();
            ServerLibrary.ServerConnectionUDP connection = new ServerLibrary.ServerConnectionUDP("Tester");

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            server.AddConnection(connection);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------
            List<Packet> packets = server.RecieveMessages("Tester");

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
            Assert.IsNotNull(packets);
        }
    }
}
