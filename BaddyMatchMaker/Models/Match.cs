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

        public int MatchId { get; set; }
        public byte CourtNumber { get; set; }
        public int RoundId { get; set; }

        public virtual Round Round { get; set; }
        public virtual ICollection<PlayerMatch> PlayerMatches { get; set; }
    }
}
