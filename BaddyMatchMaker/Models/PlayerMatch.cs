using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class PlayerMatch
    {
        public int PlayerMatchId { get; protected set; }
        public int MatchId { get; protected set; }
        public int PlayerId { get; protected set; }

        public virtual Match Match { get; protected set; }
        public virtual Player Player { get; protected set; }
    }
}
