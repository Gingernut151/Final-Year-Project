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
    class Start
    {
        ServerLibrary.TCPClient client;
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 3520);
        Socket socket;
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Start - 
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerTcpClientStart()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            server.Start();
            Thread thread = new Thread(AcceptSocket);
            thread.Start();

            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 3520;

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3520);
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(localEndPoint);

            DotNetserialization serializer = new DotNetserialization();
            ServerListenerTCP listener = new ServerListenerTCP(config);
            Thread.Sleep(50);

            client.AddListener(listener);
            client.AddSerializer(serializer);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            client.Start();

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
