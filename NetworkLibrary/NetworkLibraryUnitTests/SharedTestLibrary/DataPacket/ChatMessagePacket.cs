using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Compatibility;

using SharedLibrary;

namespace NetworkLibraryUnitTests.SharedTestLibrary.DataPacket
{
    [TestFixture]
    class ChatMessagePacket_Constrcutor
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Chat Message Constructor
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ConstrcutorChatMessagePacket()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            SharedLibrary.ChatMessagePacket packet;

            PacketType expectedType = PacketType.CHATMESSAGE;
            string expectedMessage = "I am a test";
            string expectedSender = "Tester";

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            packet = new SharedLibrary.ChatMessagePacket("I am a test", "Tester");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
            Assert.IsNotNull(packet);
            Assert.AreEqual(expectedMessage, packet.message);
            Assert.AreEqual(expectedType, packet.type);
            Assert.AreEqual(expectedSender, packet.sender);
        }
    }
}
