using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.ServerConnection
{
    [TestFixture]
    class ServerConnection
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Server Connection Constructor - The Constrcutor for the Server Connection
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerConnectionConstructor()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ServerLibrary.ServerConnectionUDP connection;

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            connection = new ServerLibrary.ServerConnectionUDP("Tester");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
