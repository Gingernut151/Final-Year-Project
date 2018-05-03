using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;

namespace NetworkLibraryUnitTests.ServerTestLibrary.ServerClient.UDPClient
{
    [TestFixture]
    class AddSerializer
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Add DotNetSerializer - This adds the serializer to the connection.
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerUdpClientAddDotNetSerializer()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ServerLibrary.UDPClient client = new ServerLibrary.UDPClient("Tester");
            DotNetserialization serializer = new DotNetserialization();

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
    }
}
