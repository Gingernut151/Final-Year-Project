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

namespace NetworkLibraryUnitTests.ServerTestLibrary.ServerClient.TCPClient
{
    [TestFixture]
    class AddListener
    {
        ServerLibrary.TCPClient client;
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 11000);
        Socket socket;
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Add Tcp Listener - This adds the listener to the connection.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerTcpClientAddListener()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            server.Start();
            Thread thread = new Thread(AcceptSocket);
            thread.Start();

            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4514;

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(localEndPoint);

            ServerListenerTCP listener = new ServerListenerTCP(config);
            Thread.Sleep(50);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            client.AddListener(listener);

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
            client = new ServerLibrary.TCPClient(socket, "Tester");
        }
    }
}
