using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Round
    {
        public Round()
        {
            Matches = new HashSet<Match>();
        }

        public int RoundId { get; protected set; }
        public int SessionId { get; protected set; }
        public DateTime StartTime { get; protected set; }
        public DateTime EndTime { get; protected set; }
        public int CourtsAvailable { get; protected set; }

        public virtual Session Session { get; protected set; }
        public virtual ICollection<Match> Matches { get; protected set; }
    }
}
