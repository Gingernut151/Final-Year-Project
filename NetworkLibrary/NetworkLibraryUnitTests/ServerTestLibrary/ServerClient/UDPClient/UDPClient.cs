using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;
using ServerLibrary;


namespace NetworkLibraryUnitTests.ServerTestLibrary.ServerClient.UDPClient
{
    class UDPClient
    { 
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Udp Client Constructor - The Constrcutor for the Udp Client
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerUdpClientConstructor()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ServerLibrary.UDPClient client;

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            client = new ServerLibrary.UDPClient("Tester");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
