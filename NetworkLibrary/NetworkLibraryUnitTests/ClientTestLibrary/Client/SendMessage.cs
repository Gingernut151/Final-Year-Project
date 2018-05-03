using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ClientTestLibrary.Client
{
    [TestFixture]
    class SendMessage
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Send Messages - This will Send a message over the network on the pre selected protocol
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientSendMessage()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ChatMessagePacket packet = new ChatMessagePacket("This is a test", "Tester");

            UDP_Config config;
            config.address = "127.0.0.1";
            config.port = 4500;

            DotNetserialization serializer = new DotNetserialization();
            ClientLibrary.ClientListenerUDP listener = new ClientLibrary.ClientListenerUDP(config);
            ClientLibrary.ClientConnectionUDP connection = new ClientLibrary.ClientConnectionUDP("Test_Connection", "Tester");
            connection.AddListener(listener);
            connection.AddSerializer(serializer);
            ClientLibrary.Client client = new ClientLibrary.Client("Tester");
            client.AddConnection(connection);
            client.Start();

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            client.SendMessage(packet, "Test_Connection");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
