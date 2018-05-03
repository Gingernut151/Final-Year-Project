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
    class AddConnection
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Add Connection - This will add a connection the client object
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ClientAddConnection()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ClientLibrary.ClientConnectionUDP connection = new ClientLibrary.ClientConnectionUDP("Test_Connection", "Tester");
            ClientLibrary.Client client = new ClientLibrary.Client("Tester");

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            client.AddConnection(connection);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
