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
    class ReceiveMessage
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Receive Messages - This will return the queue of messages stored in a connection.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientReceiveMessage()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ClientLibrary.ClientConnectionUDP connection = new ClientLibrary.ClientConnectionUDP("Test_Connection", "Tester");
            ClientLibrary.Client client = new ClientLibrary.Client("Tester");
            client.AddConnection(connection);

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            client.RecieveMessages("Test_Connection");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
