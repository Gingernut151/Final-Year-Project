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
    class UsernamePacket_Constrcutor
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        // Test 1 - Username Constructor
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        [Test]
        public void ConstrcutorUsernamePacket()
        {
            //---------------------------------------------------------------------
            //Setup
            //---------------------------------------------------------------------
            SharedLibrary.UsernamePacket packet;

            PacketType expectedType = PacketType.USERNAME;
            string expectedName = "Bob the Builder";

            //---------------------------------------------------------------------
            //Run Test
            //---------------------------------------------------------------------
            packet = new SharedLibrary.UsernamePacket("Bob the Builder");

            //---------------------------------------------------------------------
            //Gather Output
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //Assert          
            //---------------------------------------------------------------------
            Assert.IsNotNull(packet);
            Assert.AreEqual(expectedName, packet.sender);
            Assert.AreEqual(expectedType, packet.type);
        }
    }
}
