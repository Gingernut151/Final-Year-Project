﻿using System;
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
    class Stop
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Stop - 
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ServerUdpClientStop()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ServerLibrary.UDPClient client = new ServerLibrary.UDPClient("Tester");

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            client.Stop();

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------

        }
    }
}
