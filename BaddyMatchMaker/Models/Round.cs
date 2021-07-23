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

        public int RoundId { get; set; }
        public int SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CourtsAvailable { get; set; }

        public virtual Session Session { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
