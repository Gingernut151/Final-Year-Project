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
    class Stop
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Stop - Stops the server from listening; clears the clients and deletes all objects attached
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerStop()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4452;

            ServerLibrary.Server server = new ServerLibrary.Server();
            ServerLibrary.ServerConnectionTCP connection = new ServerLibrary.ServerConnectionTCP("Tester");
            ServerListenerTCP listener = new ServerListenerTCP(config);
            connection.AddListener(listener);
            server.AddConnection(connection);
            server.Start();

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            server.Stop();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
        }
    }
}
