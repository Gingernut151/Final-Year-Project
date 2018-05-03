using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;

namespace NetworkLibraryUnitTests.SharedTestLibrary.Serializer.ProtoBuf
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
        public void ProtobufDeserializeChatPacket()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ProtoBufSerializer serializer = new ProtoBufSerializer();
            ChatMessagePacket Expectedpacket = new ChatMessagePacket("This is a test", "Tester");
            List<Packet> packet = new List<Packet>();
            byte[] data = { 162, 6, 16, 26, 14, 84, 104, 105, 115, 32, 105, 115, 32, 97, 32, 116, 101, 115, 116, 8, 2, 18, 6, 84, 101, 115, 116, 101, 114 };

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
