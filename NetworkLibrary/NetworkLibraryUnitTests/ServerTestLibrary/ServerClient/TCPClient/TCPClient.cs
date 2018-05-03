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
    class TCPClient
    {
        ServerLibrary.TCPClient client;
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 4480);
        Socket socket;
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Tcp Listener Constructor - The Constrcutor for the Tcp Listener
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerTcpClientConstructor()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            server.Start();
            Thread thread = new Thread(AcceptSocket);
            thread.Start();

            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4480;

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4480);
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(localEndPoint);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            // This is called in the Accept Socket function below.

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
