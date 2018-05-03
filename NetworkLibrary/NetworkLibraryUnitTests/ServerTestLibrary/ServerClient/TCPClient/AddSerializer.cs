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
    class AddSerializer
    {
        ServerLibrary.TCPClient client;
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 3514);
        Socket socket;
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Add DotNetSerializer - This adds the serializer to the connection.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerTcpClientAddDotNetSerializer()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            listener.Start();
            Thread thread = new Thread(AcceptSocket);
            thread.Start();

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3514);
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(localEndPoint);

            DotNetserialization serializer = new DotNetserialization();
            Thread.Sleep(50);
            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            client.AddSerializer(serializer);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }

        private void AcceptSocket()
        {
            socket = listener.AcceptSocket();
            client = new ServerLibrary.TCPClient(socket, "Tester");
        }
    }
}
