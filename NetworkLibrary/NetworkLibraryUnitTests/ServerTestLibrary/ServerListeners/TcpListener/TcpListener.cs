using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.Listeners.TcpListener
{
    [TestFixture]
    class TcpListener
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Tcp Listener Constructor - The Constrcutor for the Tcp Listener
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerTcpListenerConstructor()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4476;

            ServerLibrary.ServerListenerTCP listener;

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            listener = new ServerListenerTCP(config);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
