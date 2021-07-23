using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Player
    {
        public Player()
        {
            PlayerMatches = new HashSet<PlayerMatch>();
            SessionPlayers = new HashSet<SessionPlayer>();
        }

        public int PlayerId { get; protected set; }
        public string Name { get; protected set; }
        public string Sex { get; protected set; }
        public byte Grade { get; protected set; }
        public string Phone { get; protected set; }
        public string Email { get; protected set; }

        public virtual ICollection<PlayerMatch> PlayerMatches { get; protected set; }
        public virtual ICollection<SessionPlayer> SessionPlayers { get; protected set; }
    }
}
