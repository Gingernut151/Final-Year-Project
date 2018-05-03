using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.ServerConnection
{
    [TestFixture]
    class SendPacketToClient
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Send Packet To a Client - This will call the send function in the specified client.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerConnectionSendAPacketToClient()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ChatMessagePacket packet = new ChatMessagePacket("I am a test", "Tester");
            ServerLibrary.ServerConnectionUDP connection = new ServerLibrary.ServerConnectionUDP("Tester");
            
            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            connection.SendPacketToClient(packet, "Ben");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
