using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Session
    {
        private readonly List<Round> rounds;
        private readonly List<SessionPlayer> sessionPlayers;

        public Session()
        {
            rounds = new List<Round>();
            sessionPlayers = new List<SessionPlayer>();
        }

        public int SessionId { get; protected set; }
        public int ClubId { get; protected set; }
        public int VenueId { get; protected set; }
        public DateTime? StartTime { get; protected set; }
        public DateTime? EndTime { get; protected set; }

        public Club Club { get; protected set; }
        public Venue Venue { get; protected set; }
        public IReadOnlyCollection<Round> Rounds => rounds.AsReadOnly();
        public IReadOnlyCollection<SessionPlayer> SessionPlayers => sessionPlayers.AsReadOnly();

        public void SignInPlayer(SessionPlayer sessionPlayer) {
            sessionPlayers.Add(sessionPlayer);
        }
    }
}
