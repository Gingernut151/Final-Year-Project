using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using SharedLibrary;

namespace FYP_Server
{
    struct playerLobbyData
    {
        public bool isPlayer;
        public bool isReady;
        public string username;
        public string address;
        public int ping;
    }

    struct playerGameData
    {
        public string username;
        public string address;
        public Vec3 position;
        public Vec4 rotation;
    }
}
