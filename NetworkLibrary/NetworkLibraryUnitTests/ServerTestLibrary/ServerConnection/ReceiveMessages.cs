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
    class ReceiveMessages
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Receive Packets - This will return the list of packet current waiting for the user.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerConnectionReceiveMessages()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ServerLibrary.ServerConnectionUDP connection = new ServerLibrary.ServerConnectionUDP("Tester");
            List<Packet> receivedList;

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            receivedList = connection.RecieveMessages();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
