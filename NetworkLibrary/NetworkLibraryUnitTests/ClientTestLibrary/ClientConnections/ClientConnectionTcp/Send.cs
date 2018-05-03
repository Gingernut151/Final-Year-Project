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
using ClientLibrary;

namespace NetworkLibraryUnitTests.ClientTestLibrary.ClientConnections.ClientConnectionTcp
{
    [TestFixture]
    class Send
    {
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 4500);
        Socket socket;
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Send - This will serialize and Send the data on the tcp connection
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientConnectionTcpSend()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            server.Start();
            Thread thread = new Thread(AcceptSocket);
            thread.Start();

            TCP_Config config;
            config.address = "127.0.0.1";
            config.port = 4500;

            DotNetserialization serializer = new DotNetserialization();
            ClientLibrary.ClientListenerTCP listener = new ClientLibrary.ClientListenerTCP(config);
            ClientLibrary.ClientConnectionTCP connection = new ClientLibrary.ClientConnectionTCP("Test_Connection", "Tester");
            connection.AddListener(listener);
            connection.AddSerializer(serializer);
            connection.Start();

            ChatMessagePacket packet = new ChatMessagePacket("This is a test", "Tester");

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            connection.Send(packet);

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
