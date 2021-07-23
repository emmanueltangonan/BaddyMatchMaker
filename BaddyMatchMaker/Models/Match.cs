using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Match
    {
        public Match()
        {
            PlayerMatches = new HashSet<PlayerMatch>();
        }

        public int MatchId { get; protected set; }
        public byte CourtNumber { get; protected set; }
        public int RoundId { get; protected set; }

        public virtual Round Round { get; protected set; }
        public virtual ICollection<PlayerMatch> PlayerMatches { get; protected set; }
    }
}
