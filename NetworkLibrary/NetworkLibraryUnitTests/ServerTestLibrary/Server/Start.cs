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
    class Start
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Start - Starts the Server listening
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerStart()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4451;

            ServerLibrary.Server server = new ServerLibrary.Server();
            ServerLibrary.ServerConnectionTCP connection = new ServerLibrary.ServerConnectionTCP("Tester");
            ServerListenerTCP listener = new ServerListenerTCP(config);
            connection.AddListener(listener);
            server.AddConnection(connection);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            server.Start();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
