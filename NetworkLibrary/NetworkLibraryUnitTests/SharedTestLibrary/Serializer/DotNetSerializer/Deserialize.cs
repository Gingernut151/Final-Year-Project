﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;

namespace NetworkLibraryUnitTests.SharedTestLibrary.Serializer.DotNetSerializer
{
    [TestFixture]
    class Deserialize
    {      
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Deserialize Chat Packet
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void DotNetDeserializeChatPacket()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            DotNetserialization serializer = new DotNetserialization();
            ChatMessagePacket Expectedpacket = new ChatMessagePacket("This is a test", "Tester");
            List<Packet> packet = new List<Packet>();
            byte[] data = {0,1,0,0,0,255,255,255,255,1,0,0,0,0,0,0,0,12,2,0,0,0,68,83,104,97,114,101,100,76,105,98,114,97,114,
            121,44,32,86,101,114,115,105,111,110,61,49,46,48,46,48,46,48,44,32,67,117,108,116,117,114,101,61,
            110,101,117,116,114,97,108,44,32,80,117,98,108,105,99,75,101,121,84,111,107,101,110,61,110,117,108,
            108,5,1,0,0,0,31,83,104,97,114,101,100,76,105,98,114,97,114,121,46,67,104,97,116,77,101,115,115,97,
            103,101,80,97,99,107,101,116,3,0,0,0,7,109,101,115,115,97,103,101,4,116,121,112,101,6,115,101,110,
            100,101,114,1,4,1,24,83,104,97,114,101,100,76,105,98,114,97,114,121,46,80,97,99,107,101,116,84,121,
            112,101,2,0,0,0,2,0,0,0,6,3,0,0,0,14,84,104,105,115,32,105,115,32,97,32,116,101,115,116,5,252,255,
            255,255,24,83,104,97,114,101,100,76,105,98,114,97,114,121,46,80,97,99,107,101,116,84,121,112,101,1,
            0,0,0,7,118,97,108,117,101,95,95,0,8,2,0,0,0,2,0,0,0,6,5,0,0,0,6,84,101,115,116,101,114,11,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};


            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            packet.Add(serializer.Deserialize(data));

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------
            ChatMessagePacket output = (ChatMessagePacket)packet[0];
            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
            Assert.IsNotNull(data);
            Assert.AreEqual(Expectedpacket.message, output.message);
            Assert.AreEqual(Expectedpacket.sender, output.sender);
            Assert.AreEqual(Expectedpacket.type, output.type);
        }
    }
}
