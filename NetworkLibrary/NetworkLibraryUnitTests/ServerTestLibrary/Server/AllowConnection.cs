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
    class AllowConnection
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Allow Connection Started - This is here for code coverage as the sub functions are tested
        //                                     elsewhere
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerAllowConnectionStarted()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4444;

            ServerLibrary.Server server = new ServerLibrary.Server();
            ServerListenerTCP listener = new ServerListenerTCP(config);
            ServerLibrary.ServerConnectionTCP connection = new ServerLibrary.ServerConnectionTCP("Tester");
            connection.AddListener(listener);
            server.AddConnection(connection);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            server.AllowTcpConnection("Tester");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
            
        }
    }
}
