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
    class Serialize
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Serialize Chat Packet
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ProtobufSerializeChatPacket()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            ProtoBufSerializer serializer = new ProtoBufSerializer();
            ChatMessagePacket packet = new ChatMessagePacket("This is a test", "Tester");
            byte[] data;
            byte[] expectedData = { 162,6,16,26,14,84,104,105,115,32,105,115,32,97,32,116,101,115,116,8,2,18,6,84,101,115,116,101,114 };

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            data = serializer.Serialize(packet);

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
            Assert.IsNotNull(data);
            Assert.AreEqual(expectedData, data);
        }
    }
}
