using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ClientTestLibrary.ClientListener.TCPListener
{
    [TestFixture]
    class Stop
    {
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 4512);
        Socket socket;
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Stop - This disconnect the client to the server
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientListenerTcpStop()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            server.Start();
            Thread thread = new Thread(AcceptSocket);
            thread.Start();

            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4512;

            ClientLibrary.ClientListenerTCP listener = new ClientLibrary.ClientListenerTCP(config);
            listener.Start();

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            listener.Stop();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
        private void AcceptSocket()
        {
            socket = server.AcceptSocket();
        }
    }
}

