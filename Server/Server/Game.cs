using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FYP_Server
{
    class Game
    {
        List<playerLobbyData> clients;

        public void Run()
        {
            RunLobby();
            RunMatch();
        }

        private void RunLobby()
        {
            Console.WriteLine("Entering Lobby");
            LobbyServer lobby = new LobbyServer();
            lobby.InitLobbyConnection();
            lobby.StartLobbyServer();
            lobby.UpdateLobby();
            clients = lobby.GetClients();
            //lobby.CloseLobby();
        }

        private void RunMatch()
        {
            Console.WriteLine("Entering Game");
            MatchServer match = new MatchServer();
            match.InitMatch(clients);
            match.StartMatch();
            match.UpdateMatch();
        }
    }
}
