using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ClientLibrary;

namespace NetworkLibraryUnitTests.ClientTestLibrary.Client
{
    [TestFixture]
    class ClearMessage
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Clear Messages - This will empty the queue of messages on a certain connection
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientClearMessage()
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
            client.ClearMessages("Test_Connection");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
